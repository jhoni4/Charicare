﻿// Write your Javascript code.
var stripe = require("stripe")(
  "sk_test_SzVE1lDZ8Fx4Kga7b0lLvOni"
);

stripe.customers.list(
  { limit: 3 },
  function (err, customers) {
      // asynchronously called
  }
);