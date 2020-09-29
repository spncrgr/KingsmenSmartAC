<template>
  <div class="col-12 col-md-10 col-lg-7">
    <div class="input-group my-3">
      <input
        id="SearchDevices"
        placeholder="Search"
        type="text"
        class="form-control"
        aria-label="Search Devices"
        v-model="searchTerm"
      />

      <div class="input-group-append">
        <button
          type="button"
          class="btn btn-primary dropdown-toggle"
          data-toggle="dropdown"
          aria-haspopup="true"
          aria-expanded="false"
        >
          Sort by
          <span class="caret"></span>
        </button>

        <div class="dropdown-menu dropdown-menu-right">
          <a
            href="#"
            class="dropdown-item d-flex justify-content-between"
            id="deviceId"
            @click="$emit('request-key', 'deviceId')"
          >
            Device ID
            <span v-if="myKey === 'deviceId'">
              <i class="fas fa-check"></i>
            </span>
          </a>

          <a
            href="#"
            class="dropdown-item d-flex justify-content-between"
            id="serialNumber"
            @click="$emit('request-key', 'serialNumber')"
          >
            Serial Number
            <span v-if="myKey === 'serialNumber'">
              <i class="fas fa-check"></i>
            </span>
          </a>

          <a
            class="dropdown-item d-flex justify-content-between"
            href="#"
            id="firmwareVersion"
            @click="$emit('request-key', 'firmwareVersion')"
          >
            Firmware Version
            <span v-if="myKey === 'firmwareVersion'">
              <i class="fas fa-check"></i>
            </span>
          </a>

          <a
            href="#"
            class="dropdown-item d-flex justify-content-between"
            id="healthStatus"
            @click="$emit('request-key', 'healthStatus')"
          >
            Health Status
            <span v-if="myKey === 'healthStatus'">
              <i class="fas fa-check"></i>
            </span>
          </a>

          <a
            href="#"
            class="dropdown-item d-flex justify-content-between"
            id="coLevel"
            @click="$emit('request-key', 'coLevel')"
          >
            CO2 Level
            <span v-if="myKey === 'coLevel'">
              <i class="fas fa-check"></i>
            </span>
          </a>

          <a
            href="#"
            class="dropdown-item d-flex justify-content-between"
            id="temperature"
            @click="$emit('request-key', 'temperature')"
          >
            Temperature
            <span v-if="myKey === 'temperature'">
              <i class="fas fa-check"></i>
            </span>
          </a>

          <a
            href="#"
            class="dropdown-item d-flex justify-content-between"
            id="humidity"
            @click="$emit('request-key', 'humidity')"
          >
            Humidity
            <span v-if="myKey === 'humidity'">
              <i class="fas fa-check"></i>
            </span>
          </a>

          <div class="dropdown-divider" role="separator"></div>

          <a
            class="dropdown-item d-flex justify-content-between"
            href="#"
            id="asc"
            @click="$emit('request-dir', 'asc')"
          >
            Asc
            <span v-if="myDir === 'asc'">
              <i class="fas fa-check"></i>
            </span>
          </a>

          <a
            class="dropdown-item d-flex justify-content-between"
            href="#"
            id="desc"
            @click="$emit('request-dir', 'desc')"
          >
            Desc
            <span v-if="myDir === 'desc'">
              <i class="fas fa-check"></i>
            </span>
          </a>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "SearchAppointments",
  components: {},
  props: ["myKey", "myDir"],
  watch: {
    searchTerm: function() {
      this.$emit("searchRecords", this.searchTerm);
    },
  },
  data() {
    return {
      searchTerm: "",
    };
  },
};
</script>
