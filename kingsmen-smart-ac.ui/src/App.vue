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
      <PageNavigation
        :total-count="totalCount"
        :page-size="pageSize"
        :total-pages="totalPages"
        :current-page="pageNumber"
        :has-previous="hasPrev"
        :has-next="hasNext"
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
import PageNavigation from "./components/PageNavigation";

export default {
  data: function() {
    return {
      devices: [],
      filterKey: "deviceId",
      filterDir: "asc",
      searchTerms: "",
      totalCount: 0,
      pageSize: 50,
      totalPages: 0,
      pageNumber: 1,
      hasPrev: false,
      hasNext: false,
    };
  },
  components: {
    DeviceList,
    SearchDevices,
    PageNavigation,
  },
  mounted() {
    this.getDeviceList(this.pageSize, this.pageNumber);
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
    getDeviceList: function(pageSize, pageNumber) {
      axios
        .get("https://localhost:5001/api/device", {
          responseType: "json",
          params: {
            pageSize: pageSize,
            pageNumber: pageNumber,
          },
        })
        .then((response) => {
          var paginationData = JSON.parse(response.headers["x-pagination"]);
          this.totalCount = paginationData.TotalCount;
          this.pageSize = paginationData.PageSize;
          this.totalPages = paginationData.TotalPages;
          this.pageNumber = paginationData.CurrentPage;
          this.hasPrev = paginationData.HasPrevious;
          this.hasNext = paginationData.HasNext;

          this.devices = response.data;
        });
    },
    getAllDevices: function() {
      axios
        .get("http://localhost:5000/api/Device/devices", {
          responseType: "json",
        })
        .then((response) => {
          this.devices = response.data;
        });
    },
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
