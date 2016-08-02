
/**
если браузер не создает специального поля для date, то добавляем datepicker
 * 
 * @requires {modernizr.js}
 * @requires {jquery-ui.js}
 * @requires {jquery-ui.css}
 * @requires {jquery.js}
 * @param {type} ) {
    if (!Modernizr.inputtypes.date) {
        $(function () {
            $("input[type='date']")
                                .datepicker({ dateFormat
 * @param {type} "text");
            $.datepicker.regional['ru'] = {
                prevText
 * @param {type} nextText
 * @param {type} monthNames
 * @param {type} 'Февраль'
 * @param {type} 'Март'
 * @param {type} 'Апрель'
 * @param {type} 'Май'
 * @param {type} 'Июнь'
 * @param {type} 'Июль'
 * @param {type} 'Август'
 * @param {type} 'Сентябрь'
 * @param {type} 'Октябрь'
 * @param {type} 'Ноябрь'
 * @param {type} 'Декабрь']
 * @param {type} monthNamesShort
 * @param {type} 'Фев'
 * @param {type} 'Мар'
 * @param {type} 'Апр'
 * @param {type} 'Май'
 * @param {type} 'Июн'
 * @param {type} 'Июл'
 * @param {type} 'Авг'
 * @param {type} 'Сен'
 * @param {type} 'Окт'
 * @param {type} 'Ноя'
 * @param {type} 'Дек']
 * @param {type} dayNames
 * @param {type} 'понедельник'
 * @param {type} 'вторник'
 * @param {type} 'среда'
 * @param {type} 'четверг'
 * @param {type} 'пятница'
 * @param {type} 'суббота']
 * @param {type} dayNamesShort
 * @param {type} 'пнд'
 * @param {type} 'втр'
 * @param {type} 'срд'
 * @param {type} 'чтв'
 * @param {type} 'птн'
 * @param {type} 'сбт']
 * @param {type} dayNamesMin
 * @param {type} 'Пн'
 * @param {type} 'Вт'
 * @param {type} 'Ср'
 * @param {type} 'Чт'
 * @param {type} 'Пт'
 * @param {type} 'Сб']
 * @param {type} weekHeader
 * @param {type} dateFormat
 * @param {type} firstDay
 * @param {type} isRTL
 * @param {type} showMonthAfterYear
 * @param {type} yearSuffix
 */
$(function () {
    if (!Modernizr.inputtypes.date) {
        $(function () {
            $("input[type='date']")
                                .datepicker({ dateFormat: 'dd/mm/yy' })
        .get(0).setAttribute("type", "text");
            $.datepicker.regional['ru'] = {
                prevText: 'Пред',
                nextText: 'След',
                monthNames: ['Январь', 'Февраль', 'Март', 'Апрель', 'Май', 'Июнь',
                'Июль', 'Август', 'Сентябрь', 'Октябрь', 'Ноябрь', 'Декабрь'],
                monthNamesShort: ['Янв', 'Фев', 'Мар', 'Апр', 'Май', 'Июн',
                'Июл', 'Авг', 'Сен', 'Окт', 'Ноя', 'Дек'],
                dayNames: ['воскресенье', 'понедельник', 'вторник', 'среда', 'четверг', 'пятница', 'суббота'],
                dayNamesShort: ['вск', 'пнд', 'втр', 'срд', 'чтв', 'птн', 'сбт'],
                dayNamesMin: ['Вс', 'Пн', 'Вт', 'Ср', 'Чт', 'Пт', 'Сб'],
                weekHeader: 'Не',
                dateFormat: 'dd/mm/yy',
                firstDay: 1,
                isRTL: false,
                showMonthAfterYear: false,
                yearSuffix: ''
            };
            $.datepicker.setDefaults($.datepicker.regional['ru']);
        })
    }
});