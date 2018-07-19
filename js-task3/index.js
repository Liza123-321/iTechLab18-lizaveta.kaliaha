
(function  t1(global,document,console) {
    'use strict';

    let timeout_id;
    document.getElementById("task1_id").addEventListener("click",task1);
    function task1() {
        if(timeout_id!=undefined)
            clearTimeout(timeout_id)
        timeout_id=setTimeout(function () {
            console.log("Hello World");
        }, 5000);
    };
    global.handler1=task1;

})(this,document,console);


(function t2(global,document,console) {
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
        else
        if(interval_id!=undefined)
            clearInterval(interval_id);
    }

    global.handler2=task2;

})(this,document,console);


(function t3(global,document,console) {
    'use strict';

    let flag = false;
    let interval_id;
    document.getElementById("task3_id").addEventListener("click",task3);
    function task3() {
        let seconds = Math.floor(Math.random() * (4 - 1) + 1);
        flag = (flag == true ? false : true);
        console.log(flag);
        if (flag) {
            interval_id = setInterval(function () {
                if (seconds > 0) console.log(seconds + " seconds");
                else if (seconds == 0) {
                    flag = (flag == true ? false : true);
                    console.log("Hello!!!");
                }
                else {
                    if(interval_id!=undefined)
                        clearInterval(interval_id);
                }
                seconds--;
            }, 1000);
        }
        else {
            clearInterval(interval_id);
        }
    }

    global.handler3=task3;
})(this,document,console);


(function t4(global,document,console) {
    'use strict';

    let timeout_id;
    document.getElementById("task4_id").addEventListener("keypress",task4);
    function task4() {
        if(timeout_id!=undefined)
            clearTimeout(timeout_id);
        timeout_id=setTimeout(function () {
            console.log(document.getElementById("task4_id").value);
        }, 1000);
    }

    global.handler4=task4;
})(this,document,console);


