const express = require("express");
const router = express.Router();
const db = require("../db/db");
const Parameter = require("../helpers/parameter");
const httpMsg = require("../db/httpMsgs");

exports.getAll = (req, res, next) => {
  db.executeSql(
    "select * from users where discriminator = 'individual'",
    function(data, err) {
      if (err) {
        httpMsg.show500(req, res, err);
      } else {
        httpMsg.show200(req, res, data.recordset);
      }
    }
  );
};

exports.get = (req, res, next) => {
  let params = [];
  params.push(new Parameter("id", "Int", req.params.id));

  db.executeSql(
    "select * from users where discriminator = 'individual' and id = (@id)",
    function(data, err) {
      if (err) {
        httpMsg.show500(req, res, err);
      } else {
        httpMsg.show200(req, res, data.recordset, "success");
      }
    },
    params
  );
};

exports.create = (req, res, next) => {
  let params = [];
  params.push(new Parameter("name", "NVARCHAR", req.body.name));
  params.push(new Parameter("address", "NVARCHAR", req.body.name));
  params.push(new Parameter("zip", "NVARCHAR", req.body.name));
  params.push(new Parameter("city", "NVARCHAR", req.body.name));
  params.push(new Parameter("email", "NVARCHAR", req.body.name));
  params.push(new Parameter("password", "NVARCHAR", req.body.name));
  params.push(new Parameter("phone", "NVARCHAR", req.body.name));

  db.executeSql(
    "insert into Users(name, address, zip, city, email, password, phone, isAdmin, isActive, IsValidated, Discriminator) values ((@name), (@address), (@zip), (@city), (@email), (@password), (@phone), 0, 1, 0, 'Individual')",
    function(data, err) {
      if (err) {
        httpMsg.show500(req, res, err);
      } else {
        httpMsg.show200(req, res, data);
      }
    },
    params
  );
};

exports.delete = (req, res, next) => {
  let params = [];
  params.push(new Parameter("id", "Int", req.params.id));

  db.executeSql(
    "delete from users where id = (@id)",
    function(data, err) {
      if (err) {
        httpMsg.show500(req, res, err);
      } else {
        httpMsg.show200(req, res, data);
      }
    },
    params
  );
};

exports.update = (req, res, next) => {};
