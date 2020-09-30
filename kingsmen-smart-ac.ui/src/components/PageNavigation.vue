<template>
  <div class="row">
    <nav aria-label="Page navigation example">
      <ul class="pagination">
        <li class="page-item" :class="{ disabled: prevIsDisabled }">
          <a class="page-link" href="#">
            <span aria-hidden="true">Previous</span>
          </a>
        </li>
        <li
          class="page-item"
          v-for="(n, i) in Number(totalPages)"
          :key="i"
          :class="{ active: n === Number(currentPage) }"
        >
          <a class="page-link" href="#">{{ n }}</a>
        </li>
        <li class="page-item" :class="{ disabled: nextIsDisabled }">
          <a class="page-link" href="#" aria-label="Next">
            <span>Next</span>
          </a>
        </li>
      </ul>
    </nav>
  </div>
</template>

<script>
export default {
  name: "PageNavigation",
  props: [
    "totalCount",
    "pageSize",
    "totalPages",
    "currentPage",
    "hasNext",
    "hasPrevious",
  ],
  data: function() {
    return {};
  },
  computed: {
    prevIsDisabled: function() {
      if (this.hasPrevious === "false") {
        return true;
      }
      return false;
    },
    nextIsDisabled: function() {
      if (this.hasNext === "false") {
        return true;
      }
      return false;
    },
  },
};
</script>
