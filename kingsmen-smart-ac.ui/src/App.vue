<template>
  <div id="app" class="container">
    <div class="card m-5">
        <h2 class="card-header">Device List</h2>
        <div class="card-body">
      <div class="row">
        <SearchDevices
          @search-devices="searchDevices"
          @request-key="changeKey"
          @request-dir="changeDir"
          :myKey="filterKey"
          :myDir="filterDir"
        />
      </div>
      <div class="row">
        <PageSize
          :pageSize="pageSize"
          @change-page-size="setPageSize"
          @view-all-devices="unsetPageSize"
        />
      </div>
      <div class="row">
        <PageNavigation
          :total-count="totalCount"
          :page-size="pageSize"
          :total-pages="totalPages"
          :current-page="pageNumber"
          :has-previous="hasPrev"
          :has-next="hasNext"
          @change-page="changePage"
        />
      </div>
      </div>
    </div>
        <DeviceList :devices="devices" />
  </div>
</template>

<script>
import axios from "axios";

import DeviceList from "./components/DeviceList";
import SearchDevices from "./components/SearchDevices";
import PageNavigation from "./components/PageNavigation";
import PageSize from "./components/PageSize";

export default {
  data: function() {
    return {
      devices: [],
      filterKey: "deviceId",
      filterDir: "asc",
      searchTerms: "",
      totalCount: 0,
      pageSize: 500,
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
    PageSize,
  },
  mounted() {
    this.getDeviceList(this.pageSize, this.pageNumber);
  },
  computed: {
    orderByParam: function() {
      var param = this.filterKey;
      if (this.filterDir === "desc") {
        param = param + "_" + this.filterDir;
      }
      return param;
    }
  },
  methods: {
    getDeviceList: function(pageSize, pageNumber) {
      axios
        .get("https://localhost:5001/api/device", {
          responseType: "json",
          params: {
            pageSize: pageSize,
            pageNumber: pageNumber,
            searchTerms: this.searchTerms,
            orderBy: this.orderByParam,
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
      this.getDeviceList(this.pageSize, this.CurrentPage);
    },
    changeKey: function(value) {
      this.filterKey = value;
      this.getDeviceList(this.pageSize, this.CurrentPage);
    },
    changeDir: function(value) {
      this.filterDir = value;
      this.getDeviceList(this.pageSize, this.CurrentPage);
    },
    setPageSize: function(value) {
      this.pageSize = value;
      this.getDeviceList(this.pageSize, this.pageNumber);
    },
    unsetPageSize: function() {
      this.pageSize = -1;
      this.totalPages = 0;
      this.getAllDevices();
    },
    changePage: function(value) {
      this.CurrentPage = value;
      this.getDeviceList(this.pageSize, this.CurrentPage);
    }
  },
};
</script>
