$(() => {
    const askLoadFile = "-->Или загрузите текст из .txt файла <--";
    const fileLoading = "Файл загружается";

    $("#message").text(askLoadFile);

    $("#processBtn").bind("click", () => {
        $("#results").empty();
        $.post("api/Process", { filters: mapFiltersToObject("filter"), content: $("#txtarea").val() })
            .done((data) => {
                $(data).each((id, element) => {
                    $("#results").append(`<li class='list-group-item'>${element}</li>`);
                })
            });
    });

    $("#inputFile").bind("change", async () => {
        var input = document.getElementById("inputFile").files[0];
        $("#message").text(fileLoading);
        var text = await readFileAsync(input);
        $("#txtarea").val(text);
        $("#message").text(askLoadFile);
    });

    function readFileAsync(file) {
        return new Promise((resolve, reject) => {
            let reader = new FileReader();

            reader.onload = () => {
                resolve(reader.result);
            };

            reader.onerror = reject;

            reader.readAsText(file, 'utf-8');
        })
    }

    function mapFiltersToObject(name) {
        var filters = {};
        $(`input[name="${name}"`).each((id, element) => {
            let name = $(element).prop("id");
            let checked = $(element).is(":checked");
            filters[`${name}`] = checked;
        });

        return filters;
    }
});