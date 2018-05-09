$(document).ready(function(e){
    $("input[type='image']").click(function() {
        $("input[id='user-image']").click();
    });

    $('.search-panel .dropdown-menu').find('a').click(function(e) {
		e.preventDefault();
		var param = $(this).attr("href").replace("#","");
		var concept = $(this).text();
		$('.search-panel span#search_concept').text(concept);
		$('.input-group #search_param').val(param);
    });


//    $(document).on('click', '.mega-dropdown', function(e) {
//        e.stopPropagation()
//    });
});