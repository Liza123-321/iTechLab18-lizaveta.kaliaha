//1 откуда у DoSomething videos?? выполнение обоих промисов
Promise.all([loadVideosAsync(), loadMetaAsync()])
    .then(function (videos, meta) {
        DoSomething(videos, meta);
    });

//2
async function anAsyncCall() {
    var promise = await doSomethingAsync();
    promise.then(function () {
        somethingComplicated();
    });
    return promise;
};

//3 проверка если все удалились
db.getAllDocs().then(function (result) {
    return Promise.all(result.rows.forEach(function (row) {
        return db.remove(row.doc);
    }));
}).then(function () {
    // All docs must be removed!
});

//4 добавление обработки ошибок
doAsync().then(function () {
    throw new Error('nope');
}, function (err) {
}).catch(function (err) {
    console.log("Error: " + err);
});

