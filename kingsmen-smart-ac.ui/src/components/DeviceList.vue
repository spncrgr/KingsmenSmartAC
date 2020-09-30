<template>
  <table class="table table-striped">
    <thead class="thead-light">
      <th>ID</th>
      <th>Serial #</th>
      <th>Firmware Version</th>
      <th>Health Status</th>
      <th>CO2 Level</th>
      <th>Temperature</th>
      <th>Humidity</th>
    </thead>
    <tbody>
      <tr v-for="device in devices" :key="device.deviceId">
        <td>{{ device.deviceId }}</td>
        <td>{{ device.serialNumber }}</td>
        <td>{{ device.firmwareVersion }}</td>
        <td>{{ device.healthStatus }}</td>
        <td>{{ device.coLevel }}</td>
        <td>{{ device.temperature }}</td>
        <td>{{ device.humidity }}</td>
      </tr>
    </tbody>
  </table>
</template>

<script>
export default {
  props: ["devices"],
};
</script>

<style scoped></style>
