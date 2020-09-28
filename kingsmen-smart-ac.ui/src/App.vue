<template>
  <div id="app" class="container">
      <div class="row justify-content-center">

      </div>
  </div>
</template>

<script>
    import axios from "axios";
    export default {
        data: function () {
            return {
                devices: []
            }
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
