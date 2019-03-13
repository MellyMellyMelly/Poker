var reference = [2,3,4,5,6,7,8,9,10,"J","Q","K","A"]
let cardOne = 0
let cardTwo = 0
let show = false
for(let i = 0; i < reference.length; i++)
{
    $('<div>', { 
        class: 'row',
        id: i
    }).append(
        $('<div>', { 
        class: 'box bg-danger rounded'
        }).append(
            $('<div>', {
                class: 'inner'
                }).append(reference[i])
            ),
        $('<div>', {
            class: 'box bg-info rounded'
            }).append(
                $('<div>', {
                    class: 'inner',
                }).append(reference[i])
            )
        ).appendTo('.grid')
}
$('<div>', {
    class: 'form-check last',
    width: '100%'
}).append(
    $('<input>', {
        class: 'form-check-input',
        type: 'radio',
        id: 'offsuit',
        name: 'foo',
    }),
    $('<label>', {
        class: 'form-check-label rahm',
        for: 'offsuit'
    }).append("Offsuit"),
    $('<br>')
).append(
    $('<input>', {
        class: 'form-check-input',
        type: 'radio',
        id: 'suited',
        name: 'foo',
    }),
    $('<label>', {
        class: 'form-check-label rahm',
        for: 'suited'
    }).append("Suited")
)
.appendTo('.grid')
$('<button>', {
    type: 'button',
    class: 'btn btn-success forward',
    width: '100%'
}).append("Submit").appendTo('.grid')
$('<button>', {
    type: 'button',
    class: 'btn btn-warning last press',
    width: '100%'
}).append("Go Back").appendTo('.grid')
$('.bg-danger').click( () => {
    if(!show)
    {
        $('.bg-info').css('visibility', 'visible')
        show = true
    }
})
$('.bg-info').click( () => {
    $('.row').fadeOut('slow', ()=>{
        $('.last').fadeIn('slow')
    })
})
$('.press').click(()=>{
    $('.last').fadeOut('slow', ()=> {
        $('.row').fadeIn('slow')
    })
})
$('input:radio').click((ev)=>{
    $('.forward').show()
    $('.forward').addClass('last')
})
$('.forward').click((ev)=>{
    ev.preventDefault()
})