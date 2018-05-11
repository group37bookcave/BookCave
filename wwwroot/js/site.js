﻿// Write your JavaScript code.

$(document).ready(function(e){
    
    $("input[type='image']").click(function() {
        $("input[id='user-image']").click();
    });
    
    /*Submit forms*/ 
    $("input[type='submit']").click(function()
    {
        $("input[class='input-form']").submit();
    });
    
    $('.search-panel .dropdown-menu').find('a').click(function(e) {
		e.preventDefault();
		var param = $(this).attr("href").replace("#","");
		var concept = $(this).text();
		$('.search-panel span#search_concept').text(concept);
		$('.input-group #search_param').val(param);
    });
    

    $("a#filter-products").click(function() {
        $("#filter").toggle();
    })
    

//    $(document).on('click', '.mega-dropdown', function(e) {
//        e.stopPropagation()
//    });
});