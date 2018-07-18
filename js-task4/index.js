///task А
(function task_4a(console){
    'use strict';

    function delay(duration) {
        return new Promise((resolve) => {
            setTimeout(resolve, duration);
        })
    };

    function logHi() {
        console.log('hi');
    };

    delay(2000).then(logHi);
})(console);

///task Б
(function task_4b(console){
    'use strict';

    new Promise(function (resolve) {
        setTimeout(() => {
            resolve(-10);
        }, 3000)
    }).then((result) => {
        console.log(result);
        return result * 2;
    }).then((result) => {
        console.log(result);
        return new Promise(function (resolve) {
            setTimeout(() => {
                resolve(result * 2)
            }, 2000)
        })
    }).then((result) => {
        console.log(result);
    })
})(console);

//task В
(function task_4c(console){
    'use strict';

    new Promise(()=>{
        let time=Math.random() * 4 ;
        console.log(time);
        if (time < 2) {
            console.log("Normal time = " + time);
        }
        else {
            throw new Error("more then 2 sec");
        }
    }).catch((err)=>{
        console.error("CATCH: " +err);
    });
})(console)

//task Г

(function task_4d(console){
    'use strict';
    let count_function = Math.floor(Math.random()*(10-1)+1);
    let start_time= new Date();
    let all_promises=[];
    for(let i=0;i < count_function;i++){
        let time_to_console = Math.floor(Math.random()*(10-1)+1);
        all_promises.push( new Promise(function (resolve) {
            setTimeout(() => {
                resolve(time_to_console);
            }, time_to_console*1000)
        }).then((res) => {
            console.log("My number is #" + (i+1) + " console.log after " + res + " sec.");
        }))
    }
    Promise.all(all_promises).then(()=>{
        let end_time=new Date();
        console.log("All promises resolved. Time = "+ (end_time-start_time)+ " ms.");
    })
})(console);
