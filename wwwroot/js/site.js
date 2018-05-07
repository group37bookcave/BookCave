// Write your JavaScript code.

$(document).ready(function(e){
    $('.search-panel .dropdown-menu').find('a').click(function(e) {
		e.preventDefault();
		var param = $(this).attr("href").replace("#","");
		var concept = $(this).text();
		$('.search-panel span#search_concept').text(concept);
		$('.input-group #search_param').val(param);
    });

    $("#browse-hover").hover(function () {
        $("#browse-hidden").show();
    }, function () {
        $("#browse-hidden").hide();
    });

    $("#best-sellers-hover").hover(function () {
        $("#best-sellers-hidden").show();
    }, function () {
        $("#best-sellers-hidden").hide();
    });
});