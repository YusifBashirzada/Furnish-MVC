var swiper1 = new Swiper(".mainSwiper", {
      spaceBetween: 30,
      slidesPerView: 1,
      navigation: {
        nextEl: ".main-next",
        prevEl: ".main-prev",
      },
      autoHeight: true,
      mousewheel: true,
      keyboard: true,
      loop: false
});

var swiper2  = new Swiper(".collectionSwiper", {
      spaceBetween: 0,
      slidesPerView: 3,
      pagination: {
        el: ".collection-pagination",
        clickable: true,
      },
      autoHeight: true,
      mousewheel: true,
      keyboard: true,
      loop: false
});
