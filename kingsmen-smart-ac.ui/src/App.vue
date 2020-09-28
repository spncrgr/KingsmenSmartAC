<template>
  <div id="app" class="container">
      <div class="row">
          <DeviceList :devices="devices" />
      </div>
  </div>
</template>

<script>
    import axios from "axios";
    import DeviceList from "./components/DeviceList";

    export default {
        data: function () {
            return {
                devices: []
            }
        },
        components: {
            DeviceList
        },
        mounted() {
            this.fetchDeviceData();
        },
        methods: {
            fetchDeviceData: function () {
                const baseUrl = "http://localhost:5000/api/device";

                axios.get(baseUrl, {
                    responseType: "json"
                })
                    .then(response => {
                        this.devices = response.data;
                    });
            }
        }
    }
</script>
