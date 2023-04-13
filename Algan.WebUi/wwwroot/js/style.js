$.height = function(){
    return $(window).height();
}
$(".fullScreen").css({"height":"100vh"});

$('.message a').click(function(){
    $('form').animate({height: "toggle", opacity: "toggle"}, "slow");
 });