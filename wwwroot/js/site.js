// Write your JavaScript code.

$(document).ready(function(e){
    
    $("input[type='image']").click(function() {
        $("input[id='user-image']").click();
    });
    
    /*Submit forms*/ 
    $("input[type='submit']").click(function()
    {
        $("input[id='input-form']").submit();
    });
    
    $('.search-panel .dropdown-menu').find('a').click(function(e) {
		e.preventDefault();
		var param = $(this).attr("href").replace("#","");
		var concept = $(this).text();
		$('.search-panel span#search_concept').text(concept);
		$('.input-group #search_param').val(param);
    });

 

    $("#best-sellers-hover").hover(function () {
        $("#best-sellers-hidden").show();
    }, function () {
        $("#best-sellers-hidden").hide();
    });

});