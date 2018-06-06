var scrollTimeDown = 100000;
var scrollTimeUp = 100000;

function loop() {



    var ScrollPage = function() {
        var r = $.Deferred();
        animation();
        return r;
    };

    var AddElements = function() {
        var r = $.Deferred();
        addElements();
        return r;
    };


    var ClearPage = function() {
        var r = $.Deferred();

        setTimeout(function() {
            removeElements();
        }, scrollTimeUp + scrollTimeUp + 100);

        return r;
    };

   AddElements();
   ScrollPage().then(ClearPage());

}


function animation() {

    $("html, body").animate({scrollTop: $(document).height() * 8}, scrollTimeDown);

    setTimeout(function () {
        $('html, body').animate({scrollTop: 0}, scrollTimeUp);
    }, 0);

}

function addElements() {

    $.getJSON("../data/completed_work.json", function(json) {
        for(var i = 0; i < json.length; i++) {
            $('        <div id="#n' + i + '" class="main-content">' +
                '            <table class="tg">' +
                '                <tr>' +
                '                    <th class="tg-us35" rowspan="2"><img class="user-image" src="../img/person_placeholder.png"></th>' +
                '                    <th class="tg-us36">INST INBOUND</th>' +
                '                    <th class="tg-us36">KIT INBOUND</th>' +
                '                    <th class="tg-us36">PIECE INBOUND</th>' +
                '                    <th class="tg-us36">OUTBOUND</th>' +
                '                    <th class="tg-us36">KIT BUILD</th>' +
                '                    <th class="tg-us36">PUTAWAY</th>' +
                '                </tr>' +
                '                <tr>' +
                '                    <td class="tg-p8bj" rowspan="2">' + json[i].INSTRUMENT_INBOUND_TRANSFER + '</td>' +
                '                    <td class="tg-p8bj" rowspan="2">' + json[i].KIT_INBOUND_TRANSFER + '</td>' +
                '                    <td class="tg-p8bj" rowspan="2">' + json[i].PIECE_INBOUND_TRANSFER + '</td>' +
                '                    <td class="tg-p8bj" rowspan="2">' + json[i].OUTBOUND_TRANSFER + '</td>' +
                '                    <td class="tg-p8bj" rowspan="2">' + json[i].KIT_BUILD_TRANSFER + '</td>' +
                '                    <td class="tg-p8bj" rowspan="2">' + json[i].PUTAWAY_TRANSFER + '</td>' +
                '                </tr>' +
                '                <tr>' +
                '                    <td class="tg-us37">' + json[i].EMPLOYEE + '</td>' +
                '                </tr>' +
                '            </table>' +
                '        </div>').hide().appendTo('#prod-table').fadeIn((i + 1) * 2000);
        }

    });

}

function removeElements() {

    $($('#prod-table').children('.main-content').get().reverse()).each(function() {
        $(this).fadeOut(2000);
    });

    $.getJSON("../data/navigation.json", function(json) {
        console.log('changing page');
        window.location.href = json.productivity;
    });


}

