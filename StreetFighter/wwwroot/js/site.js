﻿﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

﻿function filter(jogo) {
    let cards, i;
    let count = 0;
    cards = document.getElementsByClassName("characters__card");
    buttons = document.getElementsByClassName("btn-filter");
    for (i = 0; i < cards.length; i++) {
        cards[i].parentElement.style.display = 'none';
        if (cards[i].classList.contains(jogo) || jogo === "all") {
            cards[i].parentElement.style.display = 'block';
            count += 1;
        };
    };
    for (i = 0; i < buttons.length; i++) {
        if (buttons[i].id == `btn-${jogo}`) {
            buttons[i].classList.remove("btn-sm");
            buttons[i].classList.add("btn-lg");
        }
        else {
            buttons[i].classList.remove("btn-lg");
            buttons[i].classList.add("btn-sm");
        }
    };
    if (jogo === "all") {
        document.getElementById("btn-all").classList.remove("btn-sm");
        document.getElementById("btn-all").classList.add("btn-lg");
    };
    if (count == 0) {
        document.getElementById("zeroCharacter").style.display = 'block';
    }
    else {
        document.getElementById("zeroCharacter").style.display = 'none';
    }
}  
