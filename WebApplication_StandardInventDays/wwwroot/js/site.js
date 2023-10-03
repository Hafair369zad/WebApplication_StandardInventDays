


//$(document).ready(function () {
//    // Aktifkan atau nonaktifkan sidebar saat tombol hamburger diklik
//    $("#sidebarToggle").click(function () {
//        $(".sidebar").toggleClass("active");
//        $(".content").toggleClass("active");
//    });
//});
var hamburger = document.querySelector(".hamburger");
hamburger.addEventListener("click", function () {
    document.querySelector("body").classList.toggle("active");
})

$(document).ready(function () {
    // Get the current URL path
    var currentPath = window.location.pathname;

    // Remove the trailing slash (if any)
    currentPath = currentPath.replace(/\/$/, '');

    // Find the corresponding menu item and add the "active" class
    $('#nav_accordion li').each(function () {
        var menuItem = $(this).find('a');
        var menuItemUrl = menuItem.attr('href');

        // Check if the current path matches the menu item URL
        if (currentPath === menuItemUrl) {
            menuItem.addClass('active');
        }
    });
});



document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll('.sidebar .nav-link').forEach(function (element) {

        element.addEventListener('click', function (e) {

            let nextEl = element.nextElementSibling;
            let parentEl = element.parentElement;

            if (nextEl) {
                e.preventDefault();
                let mycollapse = new bootstrap.Collapse(nextEl);

                if (nextEl.classList.contains('show')) {
                    mycollapse.hide();
                } else {
                    mycollapse.show();
                    // find other submenus with class=show
                    var opened_submenu = parentEl.parentElement.querySelector('.submenu.show');
                    // if it exists, then close all of them
                    if (opened_submenu) {
                        new bootstrap.Collapse(opened_submenu);
                    }
                }
            }
        }); // addEventListener
    }) // forEach
});
// DOMContentLoaded  end