// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var span = document.getElementsByTagName('span');
var div = document.getElementsByTagName('div');
var num = 0;
span[1].onclick = () => {
    num++;
    for (let i of div) {
        if (num == 0) {
            i.style.left = "0px"
        }
        if (num == 1) {
            i.style.left = "740px";
        }
        if (num == 2) {
            i.style.left = "1480px";
        }
        if (num == 3) {
            i.style.left = "-2220px";
        }
        if (num == 4) {
            i.style.left = "-2960px";
        }
        if (num >4) {
            num = 4;
        }

    }
}

span[0].onclick = () => {
    num--;
    for (let i of div) {
        if (num == 0) {
            i.style.left = "0px"
        }
        if (num == 1) {
            i.style.left = "740px";
        }
        if (num == 2) {
            i.style.left = "1480px";
        }
     
        if (num < 0) {
            num= 0;
        }

    }
}

$('#customer-testimonials').owlCarousel({
    loop: true,
    center: true,
    item: 3,
    margin: 10,
    autoplay: true,
    dots: true,
    autoplayTimeout: 8500,
    smartSpeed: 450,
    nav: false,
    responsive: {
        0: {
            items: 1
        },
        600: {
            items: 3
        },
        1000: {
            items: 3
        }
    }
})


$('#returndate').change(function (e) {
    e.preventDefault();

    let pickupdate = $('#pickupdate').val();
    let returndate = $('#returndate').val();
    console.log(new Date(pickupdate).getDate());
    console.log(new Date(returndate).getDate());
   
    var diff_as_date = new Date(returndate).getDate() - new Date(pickupdate).getDate();
    console.log(diff_as_date);
    let price = $('#price').val();
    console.log(price);
    let timeSpend = diff_as_date * 8;
    let amount = timeSpend * price;
    console.log(amount);
    $('#amount').val(amount);
    $('#timeSpend').val(timeSpend);
    
});