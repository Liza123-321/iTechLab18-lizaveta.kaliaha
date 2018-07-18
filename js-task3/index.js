var timeout_id;
// var test=document.getElementById("t1").addEventListener("click",task1);
function task1() {
    clearTimeout(timeout_id)
    timeout_id=setTimeout(function () {
        console.log("Hello World");
    }, 5000);
}


var flag = false;
var interval_id;
function task2() {
    flag = (flag == true ? false : true);
    console.log(flag);
    if (flag) {
        interval_id = setInterval(function () {
            console.log("You are welcome!");
        }, 1000);
    }
    else clearInterval(interval_id);
}

var flagTask2 = false;
var intervalTask2;
function task3() {
    let seconds = Math.floor(Math.random() * (4 - 1) + 1);
    flagTask2 = (flagTask2 == true ? false : true);
    console.log(flagTask2);
    if (flagTask2) {
        intervalTask2 = setInterval(function () {
            if (seconds > 0) console.log(seconds + " seconds");
            else if (seconds == 0) {
                flagTask2 = (flagTask2 == true ? false : true);
                console.log("Hello!!!");
            }
            else {
                clearInterval(intervalTask2);
            }
            seconds--;
        }, 1000);
    }
    else {
        clearInterval(intervalTask2);
    }
}

var timeout_id4;
function task4() {
    clearTimeout(timeout_id4);
    timeout_id4=setTimeout(function () {
        console.log(document.getElementById("task4_id").value);
    }, 1000);
}
