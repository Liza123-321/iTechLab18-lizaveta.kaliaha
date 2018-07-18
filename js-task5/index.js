//1 откуда у DoSomething videos?? выполнение обоих промисов
(function task5_a() {
    'use strict';

    Promise.all([loadVideosAsync(), loadMetaAsync()])
        .then(function (videos, meta) {
            DoSomething(videos, meta);
        });
})()


//2
(function task5_b() {
    'use strict';

    async function anAsyncCall() {
        var promise = await somethingComplicated(await doSomethingAsync());
        return promise;
    };
})()

//3 проверка если все удалились
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


