const popupLinks = document.querySelectorAll('.popup-link');
const body = document.querySelector('body');
const lockPadding = document.querySelectorAll('.lock-padding');

let unlock = true;

const timeout = 500;

function popupClose(popupActive, doUnlock = true) {
    if (unlock) {
        popupActive.classList.remove('open');
        if (doUnlock)
            bodyUnlock();
    }
}

function popupOpen(currentPopup) {
    if (currentPopup && unlock) {
        const popupActive = document.querySelector('.popup.open');
        if (popupActive)
            popupClose(popupActive, false);
        else
            bodyLock();

        currentPopup.classList.add('open');
        currentPopup.addEventListener("click", (e) => {
            if (!e.target.closest('.popup-body'))
                popupClose(e.target.closest('.popup'));
        });
    }
}

function bodyLock() {

    body.classList.add('lock');

    unlock = false;
    setTimeout(() => {
        unlock = true;
    }, timeout);
}

function bodyUnlock() {
    setTimeout(() => {
        lockPadding.forEach(x => x.style.paddingRight = '0px');
        body.style.paddingRight = '0px';
        body.classList.remove('lock');
    }, timeout);

    unlock = false;

    setTimeout(() => {
        unlock = true;
    }, timeout);
}

window.addEventListener("load", () => {

    if (popupLinks.length > 0) {
        for (let i = 0; i < popupLinks.length; i++) {
            const popupLink = popupLinks[i];
            popupLink.addEventListener("click", (e) => {
                const popupName = popupLink.getAttribute('href').replace('#', '');
                const currentPopup = document.getElementById(popupName);
                popupOpen(currentPopup);
                e.preventDefault();
            });
        }
    }

    const popupCloseIcon = document.querySelectorAll('.close-popup');
    if (popupCloseIcon.length > 0) {
        popupCloseIcon.forEach(x => x.addEventListener('click', (e) => {
            popupClose(x.closest('.popup'));
            e.preventDefault();
        }));
    }
    this.document.addEventListener('keydown', (e) => {
        if (e.which === 27) {
            const popupActive = document.querySelector('.popup.open');
            popupClose(popupActive);
        }
    });

});