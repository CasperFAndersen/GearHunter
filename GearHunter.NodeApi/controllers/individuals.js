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
  if (!req.body) return httpMsg.show500;

  let params = [];
  params.push(new Parameter("Name", "NVarChar", req.body.Name));
  params.push(new Parameter("Address", "NVarChar", req.body.Address));
  params.push(new Parameter("Zip", "NVarChar", req.body.Zip));
  params.push(new Parameter("City", "NVarChar", req.body.City));
  params.push(new Parameter("Email", "NVarChar", req.body.Email));
  params.push(new Parameter("Password", "NVarChar", req.body.Password));
  params.push(new Parameter("Phone", "NVarChar", req.body.Phone));
  params.push(new Parameter("isAdmin", "Bit", 0));
  params.push(new Parameter("isActive", "Bit", 1));
  params.push(new Parameter("isValidated", "Bit", 0));
  params.push(new Parameter("Discriminator", "NVarChar", "Individual"));

  db.executeSql(
    "INSERT INTO Users(name, address, zip, city, email, password, phone, isAdmin, isActive, IsValidated, Discriminator) VALUES ((@name), (@address), (@zip), (@city), (@email), (@password), (@phone), (@isAdmin), (@isActive), (@isValidated), (@Discriminator))",
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
