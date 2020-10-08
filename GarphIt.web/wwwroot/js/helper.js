window.getWindowSize = () => {
    return { height: window.innerHeight, width: window.innerWidth };
};

function getCanvasOffsets(el) {
    return { left: el.offsetLeft, top: el.offsetTop };
}