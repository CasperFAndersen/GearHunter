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
  params.push(new Parameter("name", "NVarChar", req.body.name));
  params.push(new Parameter("address", "NVarChar", req.body.address));
  params.push(new Parameter("zip", "NVarChar", req.body.zip));
  params.push(new Parameter("city", "NVarChar", req.body.city));
  params.push(new Parameter("email", "NVarChar", req.body.email));
  params.push(new Parameter("password", "NVarChar", req.body.password));
  params.push(new Parameter("phone", "NVarChar", req.body.phone));

  db.executeSql(
    "INSERT INTO Users(name, address, zip, city, email, password, phone, isAdmin, isActive, IsValidated, Discriminator) VALUES ((@name), (@address), (@zip), (@city), (@email), (@password), (@phone), 0, 1, 0, 'Individual')",
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
