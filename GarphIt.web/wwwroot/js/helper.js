function SetFocusToElement(el) {
    el.focus();
}

function getCanvasOffsets(el) {
    return { left: el.offsetLeft, top: el.offsetTop };
}

function getWidth(el) {
    return el.getBoundingClientRect().width;
}