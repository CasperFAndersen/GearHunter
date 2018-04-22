const express = require("express");
const router = express.Router();
const individualsController = require("../../controllers/individuals");

router.get("/", individualsController.getAll);
router.get("/:id", individualsController.get);
router.post("/", individualsController.create);
router.put("/:id", individualsController.update);
router.delete("/:id", individualsController.delete);

module.exports = router;
