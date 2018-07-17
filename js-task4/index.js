///task А
function delay(duration) {
    return new Promise((resolve) => {
        setTimeout(resolve, duration);
    })
}

function logHi() {
    console.log('hi');
}
//delay(2000).then(logHi);

///task Б
new Promise(function (resolve) {
    return new Promise(() =>
        setTimeout(() => {
        resolve(-10);
    }, 3000))
}).then((result) => {
    console.log(result);
    return result * 2;
}).then((result) => {
    console.log(result);
    return new Promise((resolve) =>
        setTimeout(() => {
            resolve(result * 2);
        }, 2000)
    );
}).then((result) => {
    console.log(result);
});


//task В