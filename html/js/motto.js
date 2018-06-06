var scrollTimeDown = 1000;
var scrollTimeUp = 10000;

function loop() {

    var ScrollPage = function () {
        var r = $.Deferred();
        animation();
        return r;
    };

    var AddElements = function () {
        var r = $.Deferred();
        addElement();
        return r;
    };


    var ClearPage = function () {
        var r = $.Deferred();

        setTimeout(function () {
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

function addElement() {

    $('        <div id="#n1" class="main-content-textonly">' +
        '           <h2 class="motto-h2">Patient Safety, Integrity and Quality </h2>' +
        '           <h1 class="motto-h1">Strive for the highest standards of patient safety&comma; quality and integrity</h1>' +
        '            <p class="motto-text">' +
        '                We strive for the highest standards of patient safety and quality in our products' +
        '                and services and to be recognized for world-class integrity and ethical business practices.' +
        '            </p>' +
        '        </div>').hide().appendTo('#prod-table').fadeIn(3000);

}

function removeElements() {

    $($('#prod-table').children('.main-content-textonly').get().reverse()).each(function () {
        $(this).fadeOut(2000);
    });

    $.getJSON("../data/navigation.json", function (json) {
        console.log('changing page');
        window.location.href = json.motto;
    });

}

