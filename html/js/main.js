// function loop() {
//
//     var ScrollPage = function() {
//         var r = $.Deferred();
//         animation();
//         return r;
//     };
//
//     var AddElements = function() {
//         var r = $.Deferred();
//         addElements(['#n1','#n2', '#n3']);
//         return r;
//     };
//
//
//     var ClearPage = function() {
//         var r = $.Deferred();
//         removeElements();
//         return r;
//     };
//
//     AddElements().then(
//         function() {
//             ScrollPage();
//         }).then(
//             function() {
//                 ClearPage()
//             });
// }
//
// function animation() {
//
//     $("html, body").animate({scrollTop: $(document).height()}, scrollTimeDown);
//
//     setTimeout(function () {
//         $('html, body').animate({scrollTop: 0}, scrollTimeUp);
//     }, 1);
//
// }
//
// function addElements(elements) {
//
//     for(i = 0; i < elements.length; i++) {
//         $('        <div id="' + elements[i] + '" class="main-content">' +
//             '            <table class="tg">' +
//             '                <tr>' +
//             '                    <th class="tg-us35" rowspan="2"><img class="user-image" src="img/person_placeholder.png"></th>' +
//             '                    <th class="tg-us36">INST INBOUND</th>' +
//             '                    <th class="tg-us36">KIT INBOUND</th>' +
//             '                    <th class="tg-us36">PIECE INBOUND</th>' +
//             '                    <th class="tg-us36">KIT BUILD</th>' +
//             '                    <th class="tg-us36">PUTAWAY</th>' +
//             '                    <th class="tg-us36">TOTAL TRANSFERS</th>' +
//             '                    <th class="tg-us36">PRODUCTIVITY</th>' +
//             '                </tr>' +
//             '                <tr>' +
//             '                    <td class="tg-p8bj" rowspan="2">1</td>' +
//             '                    <td class="tg-p8bj" rowspan="2">113</td>' +
//             '                    <td class="tg-p8bj" rowspan="2">36</td>' +
//             '                    <td class="tg-p8bj" rowspan="2">25</td>' +
//             '                    <td class="tg-p8bj" rowspan="2">20</td>' +
//             '                    <td class="tg-p8bj" rowspan="2">195</td>' +
//             '                    <td class="tg-p8bj" rowspan="2">139%</td>' +
//             '                </tr>' +
//             '                <tr>' +
//             '                    <td class="tg-us37">ROLANDO FLORES</td>' +
//             '                </tr>' +
//             '            </table>' +
//             '        </div>').hide().appendTo('#prod-table').fadeIn((i + 1) * 100);
//     }
// }
//
// function removeElements() {
//
//     $($('#prod-table').children('.main-content').get().reverse()).each(function() {
//         $(this).fadeOut(1000);
//     });
//
//     // [].reverse.call($('#prod-table').children()).each(function () {
//     //     $(this).fadeOut(1000);
//     // });
// }

