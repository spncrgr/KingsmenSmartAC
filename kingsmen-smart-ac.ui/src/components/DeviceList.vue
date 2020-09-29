<template>
  <div class="card mt-5">
    <h2 class="card-header">Device List</h2>
    <table class="table table-striped">
      <thead class="thead-light">
        <th>ID</th>
        <th>Serial #</th>
        <th>Firmware Version</th>
        <th>Latest Health Status</th>
        <th>Latest CO2 Level</th>
        <th>Latest Temperature</th>
        <th>Latest Humidity</th>
      </thead>
      <tbody>
        <tr v-for="device in devices" :key="device.deviceID">
          <td>{{ device.deviceID }}</td>
          <td>{{ device.serialNumber }}</td>
          <td>{{ device.firmwareVersion }}</td>
          <td>{{ device.healthStatus }}</td>
          <td>{{ device.coLevel }}</td>
          <td>{{ device.temperature }}</td>
          <td>{{ device.humidity }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  props: ["devices"],
};
</script>

<style scoped></style>
