const SERVER_ADDRESS = "http://localhost:10640/api";
const $ = require("jquery");

const ModuleAJAX = {
    select: function(tableName) {
        let tableData;
        
        $.ajax({
            method: "GET",
            url: `${SERVER_ADDRESS}/${tableName}`,
            dataType: "json",
            async: false
        })
        .done(function(data) {
            tableData = data;
        })
        .fail(function(error) {
            console.error(error);
        });

        return tableData;
    },

    insert: function(tableName, item) {
        item = JSON.stringify(item);
        $.ajax({
            method: "POST",
            url: `${SERVER_ADDRESS}/${tableName}`,
            contentType: "application/json",
            dataType: "json",
            data: item,
            async: false
        })
        .done(function(data) {
            return data;
        })
        .fail(function(error) {
            console.error(error);
        });
    },

    update: function(tableName, item, id) {
        item = JSON.stringify(item);
        $.ajax({
            method: "PUT",
            url: `${SERVER_ADDRESS}/${tableName}/${id}`,
            contentType: "application/json",
            dataType: "json",
            data: item,
            async: false
        })
        .done(function(data) {
            return data;
        })
        .fail(function(error) {
            console.error(error);
        });
    },

    delete: function(tableName, id) {        
        $.ajax({
            method: "DELETE",
            url: `${SERVER_ADDRESS}/${tableName}/${id}`,
            dataType: "json",
            async: false
        })
        .done(function(data) {
            return data;
        })
        .fail(function(error) {
            console.error(error);
        });
    }
};

module.exports = ModuleAJAX;