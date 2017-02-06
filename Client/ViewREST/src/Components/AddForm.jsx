import React, { Component } from "react";
const ModuleAJAX = require("../ModuleAJAX.js");
const classNames = require('classnames');
const $ = require("jquery");

import "../css/AddForm.sass";''

const buttonClasses = classNames({
    "btn": true,
    "btn-success":true
});

const formClasses = classNames({
    "form-inline": true,
    "addition_form": true
});

const formGroupClasses = classNames({
    "form-group": true,
    "col-md-6": true
});

const inputClasses = classNames({
    "form-control": true,
    "input-sm": true,
    "col-md-7": true
});

export default class AddForm extends Component {
    constructor(props) {
        super(props);
    }

    sendingHandler = () => {
        this.props.onAdditionHandler();

        let data = $(this.refs.additionForm).serializeObject();
        
        ModuleAJAX.insert(this.props.tableName, data);
        this.props.onChangeTableData(ModuleAJAX.select(this.props.tableName));
    }

    componentDidMount() {
        // функция для сериализации формы в объект
        $.fn.serializeObject = function () {
            var o = {};
            var a = this.serializeArray();
            $.each(a, function () {
                if (o[this.name] !== undefined) {
                    if (!o[this.name].push) {
                        o[this.name] = [o[this.name]];
                    }
                    o[this.name].push(this.value || '');
                } else {
                    o[this.name] = this.value || '';
                }
            });
            return o;
        };
    }

    render() {
        return (
            <div className="form_wrapper">
                <form className={formClasses} ref="additionForm">
                    {
                        this.props.fields.map(field =>
                            <div className={formGroupClasses} key={field.toString()}>
                                <label htmlFor={field}>{field}</label>
                                <input className={inputClasses} name={field} id={field} />
                            </div>   
                        )
                    }
                </form>
                <div className="addition_button">                    
                    <button
                        onClick={this.sendingHandler}
                        className={buttonClasses}>
                        Добавить запись
                    </button>
                </div>
            </div>
        );
    }
}