$(document).ready(function () {
    // Sidebar toggle
    $('#sidebarCollapse').on('click', function () {
        $('.sidebar').toggleClass('active');
    });

    // Close sidebar on small screens when clicking outside
    $(document).click(function (e) {
        const sidebar = $('.sidebar');
        const sidebarButton = $('#sidebarCollapse');
        
        if (!sidebar.is(e.target) && 
            !sidebarButton.is(e.target) && 
            sidebar.hasClass('active') && 
            $(window).width() <= 768) {
            sidebar.removeClass('active');
        }
    });

    // Handle active menu items
    $('.sidebar ul li').each(function() {
        const href = $(this).find('a').attr('href');
        if (window.location.pathname.indexOf(href) > -1) {
            $(this).addClass('active');
        }
    });

    // Initialize tooltips
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl)
    });

    // Initialize popovers
    var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'))
    var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
        return new bootstrap.Popover(popoverTriggerEl)
    });
});
