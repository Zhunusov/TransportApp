$(document).ready(function () {
    $("[data-autocomplete-source]").each(function () {
        var target = $(this);
        target.autocomplete({
            source: function(request, response) {
                $.getJSON(
                    target.attr("data-autocomplete-source"),
                    {
                        term: request.term,
                        countryName: $('#CountryName').val(),
                        regionName: $('#RegionName').val()
                    },
                    response
                );
            },
            minLength: 0,
            autoFocus: true
        });
    });
});

$(document).ready(function () {
    $("a.fancyimage").fancybox();
});

$(document).ready(function () {
    $("#DatePikerBegin").datepicker({minDate:0, dateFormat:"dd.mm.yy"});
    $("#DatePikerEnd").datepicker({ minDate: 0, dateFormat: "dd.mm.yy" });
});

var prev = { start: 0, stop: 0 },
    cont = $('#searchresults div.container');

$("#pagination").paging(cont.length, { // make 1337 elements navigatable
    format: '[<*>]', // define how the navigation should look like and in which order onFormat() get's called
    perpage: 3, // show 10 elements per page
    lapping: 0, // don't overlap pages for the moment    
    page: 1, // start at page, can also be "null" or negative
    onSelect: function (page) {
        var data = this.slice;

        cont.slice(prev[0], prev[1]).css('display', 'none');
        cont.slice(data[0], data[1]).fadeIn("slow");

        prev = data;
        return true;        
        console.log(this);
    },
    onFormat: function (type) {
        switch (type) {
            case 'block': // n and c
                return '<li><a href="#">' + this.value + '</a></li>';
            case 'next': // >
                return '<li><a href="#">&gt;</a></li>';
            case 'prev': // <
                return '<li><a href="#">&lt;</a></li>';
            case 'first': // [
                return '<li><a href="#">first</a></li>';
            case 'last': // ]
                return '<li><a href="#">last</a></li>';
        }
    }
});