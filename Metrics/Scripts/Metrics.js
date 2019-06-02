$(() => {
    const askLoadFile = "-->Или загрузите текст из .txt файла <--";
    const fileLoading = "Файл загружается";

    $("#message").text(askLoadFile);

    $("#processBtn").bind("click", () => {
        $("#results").empty();
        $.post("api/Process", { filter: mapFiltersToObject("filter"), text: $("#txtarea").val() })
            .done((data) => {
                $(data).each((id, element) => {
                    $("#results").append(`<li class='list-group-item'>${element}</li>`);
                })
            });
    });

    $("#inputFile").bind("change", async () => {
        let input = document.getElementById("inputFile").files[0];
        $("#message").text(fileLoading);
        let text = await readFileAsync(input);
        $("#txtarea").val(text);
        $("#message").text(askLoadFile);
    });

    const readFileAsync = file => {
        return new Promise((resolve, reject) => {
            let reader = new FileReader();

            reader.onload = () => {
                resolve(reader.result);
            };

            reader.onerror = reject;

            reader.readAsText(file, 'utf-8');
        })
    }

    const mapFiltersToObject = name => {
        let filters = {};
        $(`input[name="${name}"`).each((id, element) => {
            let name = $(element).prop("id");
            let checked = $(element).is(":checked");
            filters[`${name}`] = checked;
        });

        return filters;
    }
});