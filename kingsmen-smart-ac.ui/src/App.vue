<template>
  <div id="app" class="container">
    <div class="row">
      <SearchDevices
        @searchRecords="searchDevices"
        @request-key="changeKey"
        @request-dir="changeDir"
        :myKey="filterKey"
        :myDir="filterDir"
      />
      <DeviceList :devices="filteredDevices" />
    </div>
  </div>
</template>

<script>
import axios from "axios";
import _ from "lodash";

import DeviceList from "./components/DeviceList";
import SearchDevices from "./components/SearchDevices";

export default {
  data: function() {
    return {
      devices: [],
      filterKey: "deviceId",
      filterDir: "asc",
      searchTerms: "",
    };
  },
  components: {
    DeviceList,
    SearchDevices,
  },
  mounted() {
    axios
      .get("http://localhost:5000/api/device", {
        responseType: "json",
      })
      .then((response) => {
        this.devices = response.data;
      });
  },
  computed: {
    searchedDevices: function() {
      return this.devices.filter((item) => {
        return (
          item.deviceId === Number(this.searchTerms) ||
          item.firmwareVersion
            .toLowerCase()
            .match(this.searchTerms.toLowerCase()) ||
          item.serialNumber.toLowerCase().match(this.searchTerms.toLowerCase())
        );
      });
    },
    filteredDevices: function() {
      return _.orderBy(
        this.searchedDevices,
        (item) => {
          return item[this.filterKey];
        },
        this.filterDir
      );
    },
  },
  methods: {
    searchDevices: function(terms) {
      this.searchTerms = terms;
    },
    changeKey: function(value) {
      this.filterKey = value;
    },
    changeDir: function(value) {
      this.filterDir = value;
    },
  },
};
</script>
