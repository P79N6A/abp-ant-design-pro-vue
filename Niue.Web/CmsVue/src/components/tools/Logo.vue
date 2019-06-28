<template>
  <div class="logo">
    <router-link :to="{name:'dashboard'}">
      <LogoSvg alt="logo" id="logo" />
      <TitleSvg v-if="showTitle" alt="title" id="title" />
    </router-link>
  </div>
</template>

<script>
import LogoSvg from '@/assets/logo.svg?inline'
import TitleSvg from '@/assets/title.svg?inline'

export default {
  name: 'Logo',
  components: {
    LogoSvg,
    TitleSvg
  },
  props: {
    showTitle: {
      type: Boolean,
      default: true,
      required: false
    }
  }
}
</script>
