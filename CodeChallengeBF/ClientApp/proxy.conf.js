const { env } = require("process");

// launchSettings.json set default to "http://localhost:5001"
const target = env.ASPNETCORE_URLS || "http://localhost:5001";

const PROXY_CONFIG = [
  {
    context: ["/testform"],
    proxyTimeout: 10000,
    target,
    secure: false,
    headers: {
      Connection: "Keep-Alive",
    },
  },
];

module.exports = PROXY_CONFIG;
