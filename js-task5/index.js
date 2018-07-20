//1  выполнение обоих промисов (рабочий пример)
(function task5_a() {
    'use strict';

    function loadVideosAsync() {
      return  new Promise(function (resolve) {
            setTimeout(() => {
                resolve("video");
            }, 4000)
        })
    }
    function loadMetaAsync() {
        return  new Promise(function (resolve) {
            setTimeout(() => {
                resolve("meta");
            }, 2000)
        })
    }
    function DoSomething(videos,meta) {
       console.log(videos + meta);

    };

    Promise.all([loadVideosAsync(), loadMetaAsync()])
        .then(function (result) {
            DoSomething(result[0],result[1]);
        });
})()


//2
(function task5_b() {
    'use strict';

    function somethingComplicated() {
      return  new Promise(()=> {
            setTimeout(() => {
            }, 1000)
        })
     }
    function doSomethingAsync() {
        return  new Promise(()=>{
            setTimeout(() => {
            }, 2000)
        })
    }
    (async function anAsyncCall() {
        var promise = await somethingComplicated(await doSomethingAsync());
        return promise;
    })();

})()

// //3 проверка если все удалились
(function task5_c() {
    'use strict';

    db.getAllDocs().then(function (result) {
        return Promise.all(result.rows.forEach(function (row) {
            return db.remove(row.doc);
        }));
    }).then(function () {
        // All docs must be removed!
    });
})()


//4 добавление обработки ошибок
(function task5_d() {
    'use strict';

    doAsync().then(function () {
        throw new Error('nope');
    }, function (err) {
    }).catch(function (err) {
        console.log("Error: " + err);
    });
})()


