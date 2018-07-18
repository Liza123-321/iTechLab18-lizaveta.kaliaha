
(function  t1() {
    'use strict';

    let timeout_id;
    document.getElementById("task1_id").addEventListener("click",task1);
    function task1() {
        clearTimeout(timeout_id)
        timeout_id=setTimeout(function () {
            console.log("Hello World");
        }, 5000);
    }

})();


(function t2() {
    'use strict';

    let flag = false;
    let interval_id;
    document.getElementById("task2_id").addEventListener("click",task2);
    function task2() {
        flag = (flag == true ? false : true);
        console.log(flag);
        if (flag) {
            interval_id = setInterval(function () {
                console.log("You are welcome!");
            }, 3000);
        }
        else clearInterval(interval_id);
    }

})();


(function t3() {
    'use strict';

    let flagTask2 = false;
    let intervalTask2;
    document.getElementById("task3_id").addEventListener("click",task3);
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
})();


(function t4() {
    'use strict';

    let timeout_id4;
    document.getElementById("task4_id").addEventListener("keypress",task4);
    function task4() {
        clearTimeout(timeout_id4);
        timeout_id4=setTimeout(function () {
            console.log(document.getElementById("task4_id").value);
        }, 1000);
    }
})();


