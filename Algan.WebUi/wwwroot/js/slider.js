var swiper = new Swiper(".mySwiper", {
  slidesPerView: 3,
  spaceBetween: 30,
  freeMode: true,
  pagination: {
    el: ".swiper-pagination",
    clickable: false,
  },
  autoplay: {
    delay: 4000,
  },
  loop: true,
});
// var swiper4 = new Swiper(".mySwiper4", {
//   slidesPerView: 3,
//   spaceBetween: 30,
//   freeMode: true,
//   pagination: {
//     el: ".swiper-pagination",
//     clickable: false,
//   },
//   autoplay: {
//     delay: 2000,
//   },
//   loop: true,
// });
// Slider 2 Fotograf için
var swiper = new Swiper(".mySwiper2", {
  pagination: {
    el: ".swiper-pagination",
    type: "progressbar",
  },
  navigation: {
    nextEl: ".swiper-button-next",
    prevEl: ".swiper-button-prev",
  },
});
//3. slider
var swiper = new Swiper(".mySwiper3", {
  direction: "right",
  slidesPerView: 3,
  spaceBetween: 30,
  pagination: {
    el: ".swiper-pagination",
    clickable: false,
  },
});

  