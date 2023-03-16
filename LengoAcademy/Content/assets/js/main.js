/*
Template Name: Maan LMS - Education HTML Template
Author       : MaanTheme
Version      : 1.0
*/

(function ($) {
  "use strict";

  /*=============================================
        =     Menu sticky & Scroll to top      =
    =============================================*/
  $(window).on('scroll', function () {
    var scroll = $(window).scrollTop();
    if (scroll < 245) {
      $("#sticky-header").removeClass("sticky-menu");
      $('.scroll-to-target').removeClass('open');

    } else {
      $("#sticky-header").addClass("sticky-menu");
      $('.scroll-to-target').addClass('open');
    }
  });

  $("[data-background]").each(function () {
    $(this).css("background-image", "url(" + $(this).attr("data-background") + ")");
  });

  $('select').niceSelect();

  // Service Filter
  var $grid = $(".grid-active").isotope({
    itemSelector: ".grid-item",
  });

  // Portfolio Filter items on button click
  $(".grid-filter").on("click", "li", function () {
    var filterValue = $(this).attr("data-filter");
    $grid.isotope({
      filter: filterValue,
    });
  });

  // change is-checked class on buttons
  $(".grid-filter").each(function (i, buttonGroup) {
    var $buttonGroup = $(buttonGroup);
    $buttonGroup.on("click", "li", function () {
      $buttonGroup.find(".is-checked").removeClass("is-checked");
      $(this).addClass("is-checked");
    });
  });


  // Testimonial Course Slide
  var testimonial = new Swiper(".maan-testimonial-active", {
    autoplay: true,
    slidesPerView: 1,
    spaceBetween: 0,
    speed: 500,
    loop: true,
    freeMode: true,
    navigation: false,
    breakpoints: {
      768: {
        navigation: {
          nextEl: ".swiper-button-next",
          prevEl: ".swiper-button-prev"
        },
      },
    },
  });

  // Related Course Slide
  var relatedCourse = new Swiper(".maan-related-course-active", {
    slidesPerView: 1,
    spaceBetween: 0,
    loop: true,
    freeMode: true,
    navigation: {
      nextEl: ".swiper-button-next",
      prevEl: ".swiper-button-prev"
    },
    breakpoints: {
      768: {
        slidesPerView: 2,
        spaceBetween: 15,
      },
      1200: {
        slidesPerView: 4,
        spaceBetween: 15,
      },
      1440: {
        slidesPerView: 4,
        spaceBetween: 30,
      },
    },
  });

  // Client Slider
  var clientSlider = new Swiper(".maan-client-container", {
    slidesPerView: 1,
    spaceBetween: 0,
    loop: true,
    navigation: false,
    breakpoints: {
      576: {
        slidesPerView: 2,
        spaceBetween: 15,
      },
      768: {
        slidesPerView: 3,
        spaceBetween: 15,
      },
      1200: {
        slidesPerView: 4,
        spaceBetween: 30,
      },
      1440: {
        slidesPerView: 4,
        spaceBetween: 167,
      },
    },
  });

  // new js
  var popularSlider = new Swiper(".maan-lms-categorie-slide", {
    slidesPerView: 1,
    centeredSlides: false,
    slidesPerGroupSkip: 1,
    spaceBetween: 30,
    grabCursor: true,
    keyboard: {
      enabled: true,
    },
    
    breakpoints: {
      576: {
        slidesPerView: 1,
        spaceBetween: 15,
      },
      768: {
        slidesPerView: 2,
        spaceBetween: 15,
      },
      1200: {
        slidesPerView: 3,
        spaceBetween: 30,
      },
      1440: {
        slidesPerView: 4,
        spaceBetween: 30,
      },
    },
    scrollbar: {
      el: ".swiper-scrollbar",
    },
    navigation: {
      nextEl: "#p-next",
      prevEl: "#p-prev",
    },
    pagination: {
      el: ".swiper-pagination",
      type: "fraction",
    },
  });

  
  var testimonial = new Swiper(".testimonial-slide-container", {
    loop: true,
    spaceBetween: 30,
    slidesPerView: 2,
    speed: 1000,
        pagination: {
            el: '.swiper-pagination',
            clickable: true,
        },
    breakpoints: {
        1000: {
            slidesPerView: 2,
        },
        991: {
            slidesPerView: 2,
        },
        800: {
            slidesPerView: 1,
        },
        600: {
            slidesPerView: 1,
        },
        0: {
            slidesPerView: 1,
        },
    },
});

  /*===============================================
    #  Load More 
    ===============================================*/
  $("#loadMore").click(function () {
    $(".loadcontent").slideToggle('slow').toggleClass("d-flex");

    if ($(".loadcontent.d-flex").length) {
      $("#loadMore span").text("Less");
      $(".maan-sidebar-group").find(".see-more-gradient").removeClass("see-more-gradient");
    } else {
      $("#loadMore span").text("More");
      $(".maan-sidebar-group").find(".sidebar-button").addClass("see-more-gradient");
    }
  });

  $(document).ready(function () {
    $(".load-more button").on("click", function (e) {
      e.preventDefault();
      $(".hidecontent:hidden").slice(0, 3).slideDown();
      if ($(".hidecontent:hidden").length == 0) {
        $(".load-more button").text("No Content").addClass("d-none");
      }
    });
  })

  // Range Slider  
  if ($(".a").length) {
    $(".a").slider({
      range: true,
      min: 0,
      max: 500,
      values: [75, 300],
      slide: function (event, ui) {
        $(".b").text("$" + ui.values[0] + " - $" + ui.values[1]);
      }
    });
    $(".b").text("$" + $(".a").slider("values", 0) +
      " - $" + $(".a").slider("values", 1));
  }

  /*===============================================
    #  Layout Mode
    ===============================================*/
  $(".course-layout-mode").each(function (i, buttonGroup) {
    var $buttonGroup = $(buttonGroup);
    $buttonGroup.on("click", "span", function () {
      $buttonGroup.find(".d-none").removeClass("d-none");
      $(this).addClass("d-none");
    });
  });

  $(".course-layout-mode").on("click", function () {
    $(".maan-grid-layout").find(".maan-courses-grid").toggleClass("list-layout-mode");
  });

  $(".read-more-btn").on("click", function () {
    $(".maan-description-content ").find(".loadcontent").slideToggle("slow").toggleClass("d-block");
    if ($(".loadcontent.d-block").length) {
      $(".read-text").text("Read Less");
      $(".read-more-btn").find(".fa-plus-circle").addClass("fa-minus-circle");
      $(".read-more-btn").find(".fa-plus-circle").removeClass("fa-plus-circle");
    } else {
      $(".read-text").text("Read More");
      $(".read-more-btn").find(".fa-minus-circle").addClass("fa-plus-circle");
      $(".read-more-btn").find(".fa-minus-circle").removeClass("fa-minus-circle");
    }
  });

  // typed js
  function typedSlider (){
    if ($('.maan-banner-content, .maan-lsm-banner-content').length){
        var typed = new Typed('.typed', {
          strings: ["Practical Training","Education"],
          // Optionally use an HTML element to grab strings from (must wrap each string in a <p>)
          stringsElement: null,
          // typing speed
          typeSpeed: 100,
          // time before typing starts
          startDelay: 1200,
          // backspacing speed
          backSpeed: 10,
          // time before backspacing
          backDelay: 600,
          // loop
          loop: true,
          // false = infinite
          loopCount: Infinity,
          // show cursor
          showCursor: false,
          // character for cursor
          cursorChar: "|",
          // attribute to type (null == text)
          attr: null,
          // either html or text
          contentType: 'html',
          // call when done callback function
          callback: function() {},
          // starting callback function before each string
          preStringTyped: function() {},
          //callback for every typed string
          onStringTyped: function() {},
          // callback for reset
          resetCallback: function() {}
      });
    }
  }
  typedSlider ();


  // Scroll Animation
  scrollCue.init({
    percentage: 0.9,
  });



 



})(jQuery);

// Responsive Menu
document.addEventListener(
  "DOMContentLoaded", () => {
    const menu = new MmenuLight(
      document.querySelector("#menu"),
      "(max-width: 991px)"
    );

    const navigator = menu.navigation();
    const drawer = menu.offcanvas();

    document.querySelector("a[href='#menu']")
      .addEventListener("click", (evnt) => {
        evnt.preventDefault();
        drawer.open();
      });
  }
  
);

const counterUp = window.counterUp.default

if (document.querySelectorAll( '.counter' ).length) {
  const callback = entries => {
    entries.forEach( entry => {
      const el = entry.target
      if ( entry.isIntersecting && ! el.classList.contains( 'is-visible' ) ) {
          for (const counter of counters) {
            counterUp(counter, {
              duration: 1000,
              delay: 16,
            })
            el.classList.add('is-visible')
          }
        }
    } )
  }
  
  // observer
  const IO = new IntersectionObserver( callback, { threshold: 1 } )
  
  // First element to target
  const el = document.querySelector( '.counter' )
  
  // all numbers
  const counters = document.querySelectorAll( '.counter' )
  IO.observe( el )
}


// Countdown
if ($('#countdown').length) {
  const second = 1000,
    minute = second * 60,
    hour = minute * 60,
    day = hour * 24;

  //I'm adding this section so I don't have to keep updating this pen every year :-)
  //remove this if you don't need it
  let today = new Date(),
    dd = String(today.getDate()).padStart(2, "0"),
    mm = String(today.getMonth() + 1).padStart(2, "0"),
    yyyy = today.getFullYear(),
    nextYear = yyyy + 1,
    dayMonth = "09/30/",
    birthday = dayMonth + yyyy;

  today = mm + "/" + dd + "/" + yyyy;
  if (today > birthday) {
    birthday = dayMonth + nextYear;
  }
  //end

  const countDown = new Date(birthday).getTime(),
    x = setInterval(function () {

      const now = new Date().getTime(),
        distance = countDown - now;

      document.getElementById("days").innerText = Math.floor(distance / (day)),
        document.getElementById("hours").innerText = Math.floor((distance % (day)) / (hour)),
        document.getElementById("minutes").innerText = Math.floor((distance % (hour)) / (minute)),
        document.getElementById("seconds").innerText = Math.floor((distance % (minute)) / second);

      //do something later when date is reached
      if (distance < 0) {
        document.getElementById("headline").innerText = "It's my birthday!";
        document.getElementById("countdown").style.display = "none";
        document.getElementById("content").style.display = "block";
        clearInterval(x);
      }
      //seconds
    }, 0)
}






