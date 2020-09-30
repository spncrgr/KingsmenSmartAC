<template>
  <div class="dropdown my-3">
    <button
      class="btn btn-primary dropdown-toggle"
      type="button"
      id="pageSizeButton"
      data-toggle="dropdown"
    >
      Page Size
    </button>
    <div class="dropdown-menu">
      <a
        href="#"
        class="dropdown-item"
        v-for="(n, i) in [10, 25, 50, 100, 500]"
        :key="i"
        @click="$emit('change-page-size', n)"
        :class="{ active: n === Number(pageSize) }"
        >{{ n }}</a
      >
      <a href="#" class="dropdown-item" @click="$emit('view-all-devices')" :class="{ active: Number(pageSize) === -1 }"
        >All</a
      >
    </div>
  </div>
</template>

<script>
export default {
    name: "PageSize",
    props: ["pageSize"]
}
</script>
