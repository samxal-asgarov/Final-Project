$(".first").click(function(e) {
    e.preventDefault();
    $('html,body').animate({
        scrollTop: $(".second").offset().top},
        'slow');
});