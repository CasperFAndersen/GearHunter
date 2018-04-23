const express = require("express");
const app = express();
const httpMsg = require("./db/httpMsgs");
const bodyParser = require("body-parser");
const expressValidator = require("express-validator");

const individualRoutes = require("./api/routes/individuals");

app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

//set up CORS to pass correct headers
// https://www.youtube.com/watch?v=zoSJ3bNGPp0
app.use((req, res, next) => {
  res.header("Access-Control-Allow-Origin", "*");
  res.header(
    "Access-Control-Allow-Headers",
    "Origin, X-Requested-Width, Content-Type, Accept, Authorization"
  );
  if (req.method === "OPTIONS") {
    res.header("Access-Control-Allow-Methods", "PUT, POST, PATCH, DELETE, GET");
    return res.status(200).json({});
  }
  next();
});

app.use("/individuals", individualRoutes);

app.use((req, res, next) => {
  httpMsg.show404(req, res, next);
});

app.use((error, req, res, next) => {
  httpMsg.show500(req, res, error);
});

module.exports = app;
