import N from "dayjs";
import { inject as lt, computed as I, defineComponent as W, openBlock as M, createElementBlock as L, createElementVNode as U, Fragment as Q, renderList as ot, unref as O, normalizeStyle as P, renderSlot as H, createTextVNode as it, toDisplayString as X, createCommentVNode as Z, toRefs as J, ref as $, watch as ut, nextTick as kt, createBlock as st, Teleport as Qt, createVNode as wt, Transition as Xt, withCtx as q, getCurrentScope as Zt, onScopeDispose as Jt, getCurrentInstance as te, onMounted as Tt, useSlots as ee, provide as rt, withModifiers as ne, mergeProps as ae, TransitionGroup as re } from "vue";
var ct = typeof globalThis < "u" ? globalThis : typeof window < "u" ? window : typeof global < "u" ? global : typeof self < "u" ? self : {}, Lt = { exports: {} };
(function(t, i) {
  (function(n, u) {
    t.exports = u();
  })(ct, function() {
    return function(n, u) {
      u.prototype.isSameOrBefore = function(s, c) {
        return this.isSame(s, c) || this.isBefore(s, c);
      };
    };
  });
})(Lt);
const oe = Lt.exports;
var $t = { exports: {} };
(function(t, i) {
  (function(n, u) {
    t.exports = u();
  })(ct, function() {
    return function(n, u) {
      u.prototype.isSameOrAfter = function(s, c) {
        return this.isSame(s, c) || this.isAfter(s, c);
      };
    };
  });
})($t);
const ie = $t.exports;
var Gt = { exports: {} };
(function(t, i) {
  (function(n, u) {
    t.exports = u();
  })(ct, function() {
    return function(n, u, s) {
      u.prototype.isBetween = function(c, f, g, d) {
        var a = s(c), e = s(f), o = (d = d || "()")[0] === "(", l = d[1] === ")";
        return (o ? this.isAfter(a, g) : !this.isBefore(a, g)) && (l ? this.isBefore(e, g) : !this.isAfter(e, g)) || (o ? this.isBefore(a, g) : !this.isAfter(a, g)) && (l ? this.isAfter(e, g) : !this.isBefore(e, g));
      };
    };
  });
})(Gt);
const se = Gt.exports;
var It = { exports: {} };
(function(t, i) {
  (function(n, u) {
    t.exports = u();
  })(ct, function() {
    var n = { LTS: "h:mm:ss A", LT: "h:mm A", L: "MM/DD/YYYY", LL: "MMMM D, YYYY", LLL: "MMMM D, YYYY h:mm A", LLLL: "dddd, MMMM D, YYYY h:mm A" }, u = /(\[[^[]*\])|([-_:/.,()\s]+)|(A|a|YYYY|YY?|MM?M?M?|Do|DD?|hh?|HH?|mm?|ss?|S{1,3}|z|ZZ?)/g, s = /\d\d/, c = /\d\d?/, f = /\d*[^-_:/,()\s\d]+/, g = {}, d = function(v) {
      return (v = +v) + (v > 68 ? 1900 : 2e3);
    }, a = function(v) {
      return function(b) {
        this[v] = +b;
      };
    }, e = [/[+-]\d\d:?(\d\d)?|Z/, function(v) {
      (this.zone || (this.zone = {})).offset = function(b) {
        if (!b || b === "Z")
          return 0;
        var w = b.match(/([+-]|\d\d)/g), p = 60 * w[1] + (+w[2] || 0);
        return p === 0 ? 0 : w[0] === "+" ? -p : p;
      }(v);
    }], o = function(v) {
      var b = g[v];
      return b && (b.indexOf ? b : b.s.concat(b.f));
    }, l = function(v, b) {
      var w, p = g.meridiem;
      if (p) {
        for (var h = 1; h <= 24; h += 1)
          if (v.indexOf(p(h, 0, b)) > -1) {
            w = h > 12;
            break;
          }
      } else
        w = v === (b ? "pm" : "PM");
      return w;
    }, B = { A: [f, function(v) {
      this.afternoon = l(v, !1);
    }], a: [f, function(v) {
      this.afternoon = l(v, !0);
    }], S: [/\d/, function(v) {
      this.milliseconds = 100 * +v;
    }], SS: [s, function(v) {
      this.milliseconds = 10 * +v;
    }], SSS: [/\d{3}/, function(v) {
      this.milliseconds = +v;
    }], s: [c, a("seconds")], ss: [c, a("seconds")], m: [c, a("minutes")], mm: [c, a("minutes")], H: [c, a("hours")], h: [c, a("hours")], HH: [c, a("hours")], hh: [c, a("hours")], D: [c, a("day")], DD: [s, a("day")], Do: [f, function(v) {
      var b = g.ordinal, w = v.match(/\d+/);
      if (this.day = w[0], b)
        for (var p = 1; p <= 31; p += 1)
          b(p).replace(/\[|\]/g, "") === v && (this.day = p);
    }], M: [c, a("month")], MM: [s, a("month")], MMM: [f, function(v) {
      var b = o("months"), w = (o("monthsShort") || b.map(function(p) {
        return p.slice(0, 3);
      })).indexOf(v) + 1;
      if (w < 1)
        throw new Error();
      this.month = w % 12 || w;
    }], MMMM: [f, function(v) {
      var b = o("months").indexOf(v) + 1;
      if (b < 1)
        throw new Error();
      this.month = b % 12 || b;
    }], Y: [/[+-]?\d+/, a("year")], YY: [s, function(v) {
      this.year = d(v);
    }], YYYY: [/\d{4}/, a("year")], Z: e, ZZ: e };
    function D(v) {
      var b, w;
      b = v, w = g && g.formats;
      for (var p = (v = b.replace(/(\[[^\]]+])|(LTS?|l{1,4}|L{1,4})/g, function(E, C, S) {
        var k = S && S.toUpperCase();
        return C || w[S] || n[S] || w[k].replace(/(\[[^\]]+])|(MMMM|MM|DD|dddd)/g, function(T, G, R) {
          return G || R.slice(1);
        });
      })).match(u), h = p.length, x = 0; x < h; x += 1) {
        var r = p[x], y = B[r], m = y && y[0], _ = y && y[1];
        p[x] = _ ? { regex: m, parser: _ } : r.replace(/^\[|\]$/g, "");
      }
      return function(E) {
        for (var C = {}, S = 0, k = 0; S < h; S += 1) {
          var T = p[S];
          if (typeof T == "string")
            k += T.length;
          else {
            var G = T.regex, R = T.parser, j = E.slice(k), z = G.exec(j)[0];
            R.call(C, z), E = E.replace(z, "");
          }
        }
        return function(F) {
          var Y = F.afternoon;
          if (Y !== void 0) {
            var V = F.hours;
            Y ? V < 12 && (F.hours += 12) : V === 12 && (F.hours = 0), delete F.afternoon;
          }
        }(C), C;
      };
    }
    return function(v, b, w) {
      w.p.customParseFormat = !0, v && v.parseTwoDigitYear && (d = v.parseTwoDigitYear);
      var p = b.prototype, h = p.parse;
      p.parse = function(x) {
        var r = x.date, y = x.utc, m = x.args;
        this.$u = y;
        var _ = m[1];
        if (typeof _ == "string") {
          var E = m[2] === !0, C = m[3] === !0, S = E || C, k = m[2];
          C && (k = m[2]), g = this.$locale(), !E && k && (g = w.Ls[k]), this.$d = function(j, z, F) {
            try {
              if (["x", "X"].indexOf(z) > -1)
                return new Date((z === "X" ? 1e3 : 1) * j);
              var Y = D(z)(j), V = Y.year, nt = Y.month, zt = Y.day, Vt = Y.hours, qt = Y.minutes, Wt = Y.seconds, Kt = Y.milliseconds, xt = Y.zone, dt = new Date(), ft = zt || (V || nt ? 1 : dt.getDate()), gt = V || dt.getFullYear(), at = 0;
              V && !nt || (at = nt > 0 ? nt - 1 : dt.getMonth());
              var ht = Vt || 0, pt = qt || 0, mt = Wt || 0, vt = Kt || 0;
              return xt ? new Date(Date.UTC(gt, at, ft, ht, pt, mt, vt + 60 * xt.offset * 1e3)) : F ? new Date(Date.UTC(gt, at, ft, ht, pt, mt, vt)) : new Date(gt, at, ft, ht, pt, mt, vt);
            } catch {
              return new Date("");
            }
          }(r, _, y), this.init(), k && k !== !0 && (this.$L = this.locale(k).$L), S && r != this.format(_) && (this.$d = new Date("")), g = {};
        } else if (_ instanceof Array)
          for (var T = _.length, G = 1; G <= T; G += 1) {
            m[1] = _[G - 1];
            var R = w.apply(this, m);
            if (R.isValid()) {
              this.$d = R.$d, this.$L = R.$L, this.init();
              break;
            }
            G === T && (this.$d = new Date(""));
          }
        else
          h.call(this, x);
      };
    };
  });
})(It);
const le = It.exports, Rt = Symbol("CHART_ROWS_KEY"), Yt = Symbol("CONFIG_KEY"), At = Symbol("EMIT_BAR_EVENT_KEY"), Ht = Symbol("BAR_CONTAINER_KEY");
function A() {
  const t = lt(Yt);
  if (!t)
    throw Error("Failed to inject config!");
  return t;
}
const Pt = "YYYY-MM-DD HH:mm";
function tt(t = A()) {
  const { chartStart: i, chartEnd: n, barStart: u, barEnd: s, dateFormat: c } = t, f = I(() => d(i.value)), g = I(() => d(n.value)), d = (e, o) => {
    let l;
    if (o !== void 0 && typeof e != "string" && !(e instanceof Date) && (l = o === "start" ? e[u.value] : e[s.value]), typeof e == "string")
      l = e;
    else if (e instanceof Date)
      return N(e);
    const B = c.value || Pt;
    return N(l, B, !0);
  };
  return {
    chartStartDayjs: f,
    chartEndDayjs: g,
    toDayjs: d,
    format: (e, o) => o === !1 ? e instanceof Date ? e : N(e).toDate() : (typeof e == "string" || e instanceof Date ? d(e) : e).format(o)
  };
}
function Ut() {
  const { precision: t } = A(), { chartStartDayjs: i, chartEndDayjs: n } = tt(), u = I(() => {
    switch (t == null ? void 0 : t.value) {
      case "hour":
        return "day";
      case "day":
        return "month";
      case "month":
        return "year";
      default:
        throw new Error(
          "Precision prop incorrect. Must be one of the following: 'hour', 'day', 'month'"
        );
    }
  }), s = {
    hour: "HH",
    date: "DD.MMM ",
    day: "DD.MMM ",
    month: "MMMM YYYY",
    year: "YYYY"
  };
  return {
    timeaxisUnits: I(() => {
      const f = [], g = [], d = u.value === "day" ? "date" : u.value, a = t.value;
      let e = i.value.startOf(a);
      const o = n.value.diff(i.value, "minutes", !0);
      let l = 0, B = e[d]();
      for (; e.isBefore(n.value) || e.isSame(n.value); ) {
        if (e[d]() !== B) {
          let p = 0;
          if (f.length === 0)
            p = e.startOf(d).diff(i.value, "minutes", !0) / o * 100;
          else if (e.isSameOrAfter(n.value))
            p = n.value.diff(
              e.subtract(1, d).startOf(d),
              "minutes",
              !0
            ) / o * 100;
          else {
            const x = e.startOf(d), r = e.subtract(1, d).startOf(d);
            p = x.diff(r, "minutes", !0) / o * 100;
          }
          const h = e.subtract(1, d);
          f.push({
            label: h.format(s[d]),
            value: String(B),
            date: h.toDate(),
            width: String(p) + "%"
          }), l = 0, B = e[d]();
        }
        let b = 0;
        g.length === 0 ? b = e.endOf(a).diff(i.value, "minutes", !0) / o * 100 : e.add(1, a).isSameOrAfter(n.value) ? b = n.value.diff(e.startOf(a), "minutes", !0) / o * 100 : b = e.endOf(a).diff(e.startOf(a), "minutes", !0) / o * 100, g.push({
          label: e.format(s[a]),
          value: String(e[a === "day" ? "date" : a]()),
          date: e.toDate(),
          width: String(b) + "%"
        });
        const w = e;
        e = e.add(1, a), (e.isBefore(n.value) || e.isSame(n.value)) && (l += e.diff(w, "minutes", !0));
      }
      const D = n.value.isSame(n.value.startOf(d)) ? n.value[d]() - 1 : n.value[d]();
      return f.some((b) => b.value === String(D)) || (l += n.value.diff(
        e.subtract(1, a),
        "minutes",
        !0
      ), f.push({
        label: n.value.format(s[d]),
        value: String(B),
        date: n.value.toDate(),
        width: `${l / o * 100}%`
      })), { upperUnits: f, lowerUnits: g };
    })
  };
}
const ue = { class: "g-timeaxis" }, ce = { class: "g-timeunits-container" }, de = { class: "g-timeunits-container" }, fe = /* @__PURE__ */ W({
  __name: "GGanttTimeaxis",
  setup(t) {
    const { precision: i, colors: n } = A(), { timeaxisUnits: u } = Ut();
    return (s, c) => (M(), L("div", ue, [
      U("div", ce, [
        (M(!0), L(Q, null, ot(O(u).upperUnits, ({ label: f, value: g, date: d, width: a }, e) => (M(), L("div", {
          key: f,
          class: "g-upper-timeunit",
          style: P({
            background: e % 2 === 0 ? O(n).primary : O(n).secondary,
            color: O(n).text,
            width: a
          })
        }, [
          H(s.$slots, "upper-timeunit", {
            label: f,
            value: g,
            date: d
          }, () => [
            it(X(f), 1)
          ])
        ], 4))), 128))
      ]),
      U("div", de, [
        (M(!0), L(Q, null, ot(O(u).lowerUnits, ({ label: f, value: g, date: d, width: a }, e) => (M(), L("div", {
          key: f,
          class: "g-timeunit",
          style: P({
            background: e % 2 === 0 ? O(n).ternary : O(n).quartenary,
            color: O(n).text,
            flexDirection: O(i) === "hour" ? "column" : "row",
            alignItems: O(i) === "hour" ? "" : "center",
            width: a
          })
        }, [
          H(s.$slots, "timeunit", {
            label: f,
            value: g,
            date: d
          }, () => [
            it(X(f), 1)
          ]),
          O(i) === "hour" ? (M(), L("div", {
            key: 0,
            class: "g-timeaxis-hour-pin",
            style: P({ background: O(n).text })
          }, null, 4)) : Z("", !0)
        ], 4))), 128))
      ])
    ]));
  }
});
const ge = { class: "g-grid-container" }, he = /* @__PURE__ */ W({
  __name: "GGanttGrid",
  props: {
    highlightedUnits: null
  },
  setup(t) {
    const { colors: i } = A(), { timeaxisUnits: n } = Ut();
    return (u, s) => (M(), L("div", ge, [
      (M(!0), L(Q, null, ot(O(n).lowerUnits, ({ label: c, value: f, width: g }) => {
        var d;
        return M(), L("div", {
          key: c,
          class: "g-grid-line",
          style: P({
            width: g,
            background: (d = t.highlightedUnits) != null && d.includes(Number(f)) ? O(i).hoverHighlight : void 0
          })
        }, null, 4);
      }), 128))
    ]));
  }
});
const pe = /* @__PURE__ */ W({
  __name: "GGanttBarTooltip",
  props: {
    bar: null,
    modelValue: { type: Boolean }
  },
  setup(t) {
    const i = t, n = {
      hour: "HH:mm",
      day: "DD. MMM HH:mm",
      month: "DD. MMMM YYYY"
    }, u = "cadetblue", { bar: s } = J(i), { precision: c, font: f, barStart: g, barEnd: d, rowHeight: a } = A(), e = $("0px"), o = $("0px");
    ut(
      () => i.bar,
      async () => {
        var y;
        await kt();
        const w = ((y = s == null ? void 0 : s.value) == null ? void 0 : y.ganttBarConfig.id) || "";
        if (!w)
          return;
        const p = document.getElementById(w), { top: h, left: x } = (p == null ? void 0 : p.getBoundingClientRect()) || {
          top: 0,
          left: 0
        }, r = Math.max(x, 10);
        e.value = `${h + a.value - 10}px`, o.value = `${r}px`;
      },
      { deep: !0, immediate: !0 }
    );
    const l = I(() => {
      var w, p;
      return ((p = (w = s == null ? void 0 : s.value) == null ? void 0 : w.ganttBarConfig.style) == null ? void 0 : p.background) || u;
    }), { toDayjs: B } = tt(), D = I(() => {
      var w;
      return (w = s.value) == null ? void 0 : w[g.value];
    }), v = I(() => {
      var w;
      return (w = s.value) == null ? void 0 : w[d.value];
    }), b = I(() => {
      if (!(s != null && s.value))
        return "";
      const w = n[c.value], p = B(D.value).format(w), h = B(v.value).format(w);
      return `${p} \u2013 ${h}`;
    });
    return (w, p) => (M(), st(Qt, { to: "body" }, [
      wt(Xt, {
        name: "g-fade",
        mode: "out-in"
      }, {
        default: q(() => [
          t.modelValue ? (M(), L("div", {
            key: 0,
            class: "g-gantt-tooltip",
            style: P({
              top: e.value,
              left: o.value,
              fontFamily: O(f)
            })
          }, [
            U("div", {
              class: "g-gantt-tooltip-color-dot",
              style: P({ background: O(l) })
            }, null, 4),
            H(w.$slots, "default", {
              bar: O(s),
              barStart: O(D),
              barEnd: O(v)
            }, () => [
              it(X(O(b)), 1)
            ])
          ], 4)) : Z("", !0)
        ]),
        _: 3
      })
    ]));
  }
});
const _t = {
  default: {
    primary: "#eeeeee",
    secondary: "#E0E0E0",
    ternary: "#F5F5F5",
    quartenary: "#ededed",
    hoverHighlight: "rgba(204, 216, 219, 0.5)",
    text: "#404040",
    background: "white"
  },
  creamy: {
    primary: "#ffe8d9",
    secondary: "#fcdcc5",
    ternary: "#fff6f0",
    quartenary: "#f7ece6",
    hoverHighlight: "rgba(230, 221, 202, 0.5)",
    text: "#542d05",
    background: "white"
  },
  crimson: {
    primary: "#a82039",
    secondary: "#c41238",
    ternary: "#db4f56",
    quartenary: "#ce5f64",
    hoverHighlight: "rgba(196, 141, 141, 0.5)",
    text: "white",
    background: "white"
  },
  dark: {
    primary: "#404040",
    secondary: "#303030",
    ternary: "#353535",
    quartenary: "#383838",
    hoverHighlight: "rgba(159, 160, 161, 0.5)",
    text: "white",
    background: "#525252",
    toast: "#1f1f1f"
  },
  flare: {
    primary: "#e08a38",
    secondary: "#e67912",
    ternary: "#5e5145",
    quartenary: "#665648",
    hoverHighlight: "rgba(196, 141, 141, 0.5)",
    text: "white",
    background: "white"
  },
  fuchsia: {
    primary: "#de1d5a",
    secondary: "#b50b41",
    ternary: "#ff7da6",
    quartenary: "#f2799f",
    hoverHighlight: "rgba(196, 141, 141, 0.5)",
    text: "white",
    background: "white"
  },
  grove: {
    primary: "#3d9960",
    secondary: "#288542",
    ternary: "#72b585",
    quartenary: "#65a577",
    hoverHighlight: "rgba(160, 219, 171, 0.5)",
    text: "white",
    background: "white"
  },
  "material-blue": {
    primary: "#0D47A1",
    secondary: "#1565C0",
    ternary: "#42a5f5",
    quartenary: "#409fed",
    hoverHighlight: "rgba(110, 165, 196, 0.5)",
    text: "white",
    background: "white"
  },
  sky: {
    primary: "#b5e3ff",
    secondary: "#a1d6f7",
    ternary: "#d6f7ff",
    quartenary: "#d0edf4",
    hoverHighlight: "rgba(193, 202, 214, 0.5)",
    text: "#022c47",
    background: "white"
  },
  slumber: {
    primary: "#2a2f42",
    secondary: "#2f3447",
    ternary: "#35394d",
    quartenary: "#2c3044",
    hoverHighlight: "rgba(179, 162, 127, 0.5)",
    text: "#ffe0b3",
    background: "#38383b",
    toast: "#1f1f1f"
  },
  vue: {
    primary: "#258a5d",
    secondary: "#41B883",
    ternary: "#35495E",
    quartenary: "#2a3d51",
    hoverHighlight: "rgba(160, 219, 171, 0.5)",
    text: "white",
    background: "white"
  }
};
var Et;
const et = typeof window < "u";
et && ((Et = window == null ? void 0 : window.navigator) == null ? void 0 : Et.userAgent) && /iP(ad|hone|od)/.test(window.navigator.userAgent);
function me(t) {
  return typeof t == "function" ? t() : O(t);
}
function ve(t) {
  return t;
}
function ye(t) {
  return Zt() ? (Jt(t), !0) : !1;
}
function be(t, i = !0) {
  te() ? Tt(t) : i ? t() : kt(t);
}
function jt(t) {
  var i;
  const n = me(t);
  return (i = n == null ? void 0 : n.$el) != null ? i : n;
}
const we = et ? window : void 0;
et && window.document;
et && window.navigator;
et && window.location;
function Be(t, i = !1) {
  const n = $(), u = () => n.value = Boolean(t());
  return u(), be(u, i), n;
}
const yt = typeof globalThis < "u" ? globalThis : typeof window < "u" ? window : typeof global < "u" ? global : typeof self < "u" ? self : {}, bt = "__vueuse_ssr_handlers__";
yt[bt] = yt[bt] || {};
yt[bt];
var Ot = Object.getOwnPropertySymbols, xe = Object.prototype.hasOwnProperty, _e = Object.prototype.propertyIsEnumerable, Ee = (t, i) => {
  var n = {};
  for (var u in t)
    xe.call(t, u) && i.indexOf(u) < 0 && (n[u] = t[u]);
  if (t != null && Ot)
    for (var u of Ot(t))
      i.indexOf(u) < 0 && _e.call(t, u) && (n[u] = t[u]);
  return n;
};
function Oe(t, i, n = {}) {
  const u = n, { window: s = we } = u, c = Ee(u, ["window"]);
  let f;
  const g = Be(() => s && "ResizeObserver" in s), d = () => {
    f && (f.disconnect(), f = void 0);
  }, a = ut(() => jt(t), (o) => {
    d(), g.value && s && o && (f = new ResizeObserver(i), f.observe(o, c));
  }, { immediate: !0, flush: "post" }), e = () => {
    d(), a();
  };
  return ye(e), {
    isSupported: g,
    stop: e
  };
}
function De(t, i = { width: 0, height: 0 }, n = {}) {
  const u = $(i.width), s = $(i.height);
  return Oe(t, ([c]) => {
    u.value = c.contentRect.width, s.value = c.contentRect.height;
  }, n), ut(() => jt(t), (c) => {
    u.value = c ? i.width : 0, s.value = c ? i.height : 0;
  }), {
    width: u,
    height: s
  };
}
var Dt;
(function(t) {
  t.UP = "UP", t.RIGHT = "RIGHT", t.DOWN = "DOWN", t.LEFT = "LEFT", t.NONE = "NONE";
})(Dt || (Dt = {}));
var Ce = Object.defineProperty, Ct = Object.getOwnPropertySymbols, Se = Object.prototype.hasOwnProperty, Me = Object.prototype.propertyIsEnumerable, St = (t, i, n) => i in t ? Ce(t, i, { enumerable: !0, configurable: !0, writable: !0, value: n }) : t[i] = n, ke = (t, i) => {
  for (var n in i || (i = {}))
    Se.call(i, n) && St(t, n, i[n]);
  if (Ct)
    for (var n of Ct(i))
      Me.call(i, n) && St(t, n, i[n]);
  return t;
};
const Te = {
  easeInSine: [0.12, 0, 0.39, 0],
  easeOutSine: [0.61, 1, 0.88, 1],
  easeInOutSine: [0.37, 0, 0.63, 1],
  easeInQuad: [0.11, 0, 0.5, 0],
  easeOutQuad: [0.5, 1, 0.89, 1],
  easeInOutQuad: [0.45, 0, 0.55, 1],
  easeInCubic: [0.32, 0, 0.67, 0],
  easeOutCubic: [0.33, 1, 0.68, 1],
  easeInOutCubic: [0.65, 0, 0.35, 1],
  easeInQuart: [0.5, 0, 0.75, 0],
  easeOutQuart: [0.25, 1, 0.5, 1],
  easeInOutQuart: [0.76, 0, 0.24, 1],
  easeInQuint: [0.64, 0, 0.78, 0],
  easeOutQuint: [0.22, 1, 0.36, 1],
  easeInOutQuint: [0.83, 0, 0.17, 1],
  easeInExpo: [0.7, 0, 0.84, 0],
  easeOutExpo: [0.16, 1, 0.3, 1],
  easeInOutExpo: [0.87, 0, 0.13, 1],
  easeInCirc: [0.55, 0, 1, 0.45],
  easeOutCirc: [0, 0.55, 0.45, 1],
  easeInOutCirc: [0.85, 0, 0.15, 1],
  easeInBack: [0.36, 0, 0.66, -0.56],
  easeOutBack: [0.34, 1.56, 0.64, 1],
  easeInOutBack: [0.68, -0.6, 0.32, 1.6]
};
ke({
  linear: ve
}, Te);
const Le = { class: "g-gantt-rows-container" }, $e = /* @__PURE__ */ W({
  __name: "GGanttChart",
  props: {
    chartStart: null,
    chartEnd: null,
    precision: { default: "day" },
    barStart: null,
    barEnd: null,
    dateFormat: { type: [String, Boolean], default: Pt },
    width: { default: "100%" },
    hideTimeaxis: { type: Boolean, default: !1 },
    colorScheme: { default: "default" },
    grid: { type: Boolean, default: !1 },
    pushOnOverlap: { type: Boolean, default: !1 },
    noOverlap: { type: Boolean, default: !1 },
    rowHeight: { default: 40 },
    highlightedUnits: { default: () => [] },
    font: { default: "inherit" }
  },
  emits: ["click-bar", "mousedown-bar", "mouseup-bar", "dblclick-bar", "mouseenter-bar", "mouseleave-bar", "dragstart-bar", "drag-bar", "dragend-bar", "contextmenu-bar"],
  setup(t, { emit: i }) {
    const n = t, { width: u, font: s, colorScheme: c } = J(n), f = ee(), g = I(
      () => typeof c.value != "string" ? c.value : _t[c.value] || _t.default
    ), d = () => {
      var x;
      const p = (x = f.default) == null ? void 0 : x.call(f), h = [];
      return p && p.forEach((r) => {
        var y;
        if ((y = r.props) != null && y.bars) {
          const m = r.props.bars;
          h.push(m);
        } else
          Array.isArray(r.children) && r.children.forEach((m) => {
            var E;
            const _ = m;
            if ((E = _ == null ? void 0 : _.props) != null && E.bars) {
              const C = _.props.bars;
              h.push(C);
            }
          });
      }), h;
    }, a = $(!1), e = $(!1), o = $(void 0);
    let l;
    const B = (p) => {
      l && clearTimeout(l), l = setTimeout(() => {
        a.value = !0;
      }, 800), o.value = p;
    }, D = () => {
      clearTimeout(l), a.value = !1;
    }, v = (p, h, x, r) => {
      switch (p.type) {
        case "click":
          i("click-bar", { bar: h, e: p, datetime: x });
          break;
        case "mousedown":
          i("mousedown-bar", { bar: h, e: p, datetime: x });
          break;
        case "mouseup":
          i("mouseup-bar", { bar: h, e: p, datetime: x });
          break;
        case "dblclick":
          i("dblclick-bar", { bar: h, e: p, datetime: x });
          break;
        case "mouseenter":
          B(h), i("mouseenter-bar", { bar: h, e: p });
          break;
        case "mouseleave":
          D(), i("mouseleave-bar", { bar: h, e: p });
          break;
        case "dragstart":
          e.value = !0, i("dragstart-bar", { bar: h, e: p });
          break;
        case "drag":
          i("drag-bar", { bar: h, e: p });
          break;
        case "dragend":
          e.value = !1, i("dragend-bar", { bar: h, e: p, movedBars: r });
          break;
        case "contextmenu":
          i("contextmenu-bar", { bar: h, e: p, datetime: x });
          break;
      }
    }, b = $(null), w = De(b);
    return rt(Rt, d), rt(Yt, {
      ...J(n),
      colors: g,
      chartSize: w
    }), rt(At, v), (p, h) => (M(), L("div", {
      ref_key: "ganttChart",
      ref: b,
      class: "g-gantt-chart",
      style: P({ width: O(u), background: O(g).background, fontFamily: O(s) })
    }, [
      t.hideTimeaxis ? Z("", !0) : (M(), st(fe, { key: 0 }, {
        "upper-timeunit": q(({ label: x, value: r, date: y }) => [
          H(p.$slots, "upper-timeunit", {
            label: x,
            value: r,
            date: y
          })
        ]),
        timeunit: q(({ label: x, value: r, date: y }) => [
          H(p.$slots, "timeunit", {
            label: x,
            value: r,
            date: y
          })
        ]),
        _: 3
      })),
      t.grid ? (M(), st(he, {
        key: 1,
        "highlighted-units": t.highlightedUnits
      }, null, 8, ["highlighted-units"])) : Z("", !0),
      U("div", Le, [
        H(p.$slots, "default")
      ]),
      wt(pe, {
        "model-value": a.value || e.value,
        bar: o.value
      }, {
        default: q(() => [
          H(p.$slots, "bar-tooltip", { bar: o.value })
        ]),
        _: 3
      }, 8, ["model-value", "bar"])
    ], 4));
  }
});
function Bt(t = A()) {
  const { dateFormat: i, chartSize: n } = t, { chartStartDayjs: u, chartEndDayjs: s, toDayjs: c, format: f } = tt(t), g = I(() => s.value.diff(u.value, "minutes"));
  return {
    mapTimeToPosition: (e) => {
      const o = n.width.value || 0, l = c(e).diff(u.value, "minutes", !0);
      return Math.ceil(l / g.value * o);
    },
    mapPositionToTime: (e) => {
      const o = n.width.value || 0, l = e / o * g.value;
      return f(u.value.add(l, "minutes"), i.value);
    }
  };
}
function Mt(t, i = () => null, n = () => null, u = A()) {
  const { barStart: s, barEnd: c, pushOnOverlap: f } = u, g = $(!1);
  let d = 0, a;
  const { mapPositionToTime: e } = Bt(u), { toDayjs: o } = tt(u), l = (h) => {
    const x = document.getElementById(t.ganttBarConfig.id);
    if (!x)
      return;
    switch (d = h.clientX - (x.getBoundingClientRect().left || 0), h.target.className) {
      case "g-gantt-bar-handle-left":
        document.body.style.cursor = "ew-resize", a = v;
        break;
      case "g-gantt-bar-handle-right":
        document.body.style.cursor = "ew-resize", a = b;
        break;
      default:
        a = D;
    }
    g.value = !0, window.addEventListener("mousemove", a), window.addEventListener("mouseup", p);
  }, B = () => {
    var r;
    const h = document.getElementById(t.ganttBarConfig.id), x = (r = h == null ? void 0 : h.closest(".g-gantt-row-bars-container")) == null ? void 0 : r.getBoundingClientRect();
    return { barElement: h, barContainer: x };
  }, D = (h) => {
    const { barElement: x, barContainer: r } = B();
    if (!x || !r)
      return;
    const y = x.getBoundingClientRect().width, m = h.clientX - r.left - d, _ = m + y;
    w(m, _) || (t[s.value] = e(m), t[c.value] = e(_), i(h, t));
  }, v = (h) => {
    const { barElement: x, barContainer: r } = B();
    if (!x || !r)
      return;
    const y = h.clientX - r.left, m = e(y);
    o(m).isSameOrAfter(o(t, "end")) || (t[s.value] = m, i(h, t));
  }, b = (h) => {
    const { barElement: x, barContainer: r } = B();
    if (!x || !r)
      return;
    const y = h.clientX - r.left, m = e(y);
    o(m).isSameOrBefore(o(t, "start")) || (t[c.value] = m, i(h, t));
  }, w = (h, x) => {
    if (!f.value)
      return !1;
    const r = t.ganttBarConfig.dragLimitLeft, y = t.ganttBarConfig.dragLimitRight;
    return h && r != null && h < r || x && y != null && x > y;
  }, p = (h) => {
    g.value = !1, document.body.style.cursor = "", window.removeEventListener("mousemove", a), window.removeEventListener("mouseup", p), n(h, t);
  };
  return {
    isDragging: g,
    initDrag: l
  };
}
function Ft() {
  const t = lt(Rt);
  if (!t)
    throw Error("Failed to inject getChartRows!");
  return t;
}
function Nt() {
  const t = lt(At);
  if (!t)
    throw Error("Failed to inject emitBarEvent!");
  return t;
}
function Ge() {
  const t = A(), i = Ft(), n = Nt(), { pushOnOverlap: u, barStart: s, barEnd: c, noOverlap: f, dateFormat: g } = t, d = /* @__PURE__ */ new Map(), { toDayjs: a, format: e } = tt(), o = (r, y) => {
    const { initDrag: m } = Mt(r, B, p, t);
    n({ ...y, type: "dragstart" }, r), m(y), h(r);
  }, l = (r, y) => {
    const m = r.ganttBarConfig.bundle;
    m != null && (i().forEach((_) => {
      _.forEach((E) => {
        if (E.ganttBarConfig.bundle === m) {
          const C = E === r ? p : () => null, { initDrag: S } = Mt(E, B, C, t);
          S(y), h(E);
        }
      });
    }), n({ ...y, type: "dragstart" }, r));
  }, B = (r, y) => {
    n({ ...r, type: "drag" }, y), D(y);
  }, D = (r) => {
    if (!(u != null && u.value))
      return;
    let y = r, { overlapBar: m, overlapType: _ } = v(y);
    for (; m; ) {
      h(m);
      const E = a(y[s.value]), C = a(y[c.value]), S = a(m[s.value]), k = a(m[c.value]);
      let T;
      switch (_) {
        case "left":
          T = k.diff(E, "minutes", !0), m[c.value] = e(y[s.value], g.value), m[s.value] = e(
            S.subtract(T, "minutes"),
            g.value
          );
          break;
        case "right":
          T = C.diff(S, "minutes", !0), m[s.value] = e(C, g.value), m[c.value] = e(
            k.add(T, "minutes"),
            g.value
          );
          break;
        default:
          console.warn(
            "Vue-Ganttastic: One bar is inside of the other one! This should never occur while push-on-overlap is active!"
          );
          return;
      }
      m && (_ === "left" || _ === "right") && b(m, T, _), y = m, { overlapBar: m, overlapType: _ } = v(m);
    }
  }, v = (r) => {
    let y, m, _;
    const E = i().find((G) => G.includes(r)) || [], C = a(r[s.value]), S = a(r[c.value]);
    return { overlapBar: E.find((G) => {
      if (G === r)
        return !1;
      const R = a(G[s.value]), j = a(G[c.value]);
      return y = C.isBetween(R, j), m = S.isBetween(R, j), _ = R.isBetween(C, S) || j.isBetween(C, S), y || m || _;
    }), overlapType: y ? "left" : m ? "right" : _ ? "between" : null };
  }, b = (r, y, m) => {
    h(r), r.ganttBarConfig.bundle && i().forEach((_) => {
      _.forEach((E) => {
        E.ganttBarConfig.bundle === r.ganttBarConfig.bundle && E !== r && (h(E), w(E, y, m));
      });
    });
  }, w = (r, y, m) => {
    switch (m) {
      case "left":
        r[s.value] = e(
          a(r, "start").subtract(y, "minutes"),
          g.value
        ), r[c.value] = e(
          a(r, "end").subtract(y, "minutes"),
          g.value
        );
        break;
      case "right":
        r[s.value] = e(
          a(r, "start").add(y, "minutes"),
          g.value
        ), r[c.value] = e(a(r, "end").add(y, "minutes"), g.value);
    }
    D(r);
  }, p = (r, y) => {
    x();
    const m = {
      ...r,
      type: "dragend"
    };
    n(m, y, void 0, new Map(d)), d.clear();
  }, h = (r) => {
    if (!d.has(r)) {
      const y = r[s.value], m = r[c.value];
      d.set(r, { oldStart: y, oldEnd: m });
    }
  }, x = () => {
    if (u.value || !f.value)
      return;
    let r = !1;
    d.forEach((y, m) => {
      const { overlapBar: _ } = v(m);
      _ != null && (r = !0);
    }), r && d.forEach(({ oldStart: y, oldEnd: m }, _) => {
      _[s.value] = y, _[c.value] = m;
    });
  };
  return {
    initDragOfBar: o,
    initDragOfBundle: l
  };
}
function Ie() {
  const { pushOnOverlap: t } = A(), i = Ft(), n = (f) => {
    const g = [];
    return f != null && i().forEach((d) => {
      d.forEach((a) => {
        a.ganttBarConfig.bundle === f && g.push(a);
      });
    }), g;
  }, u = (f) => {
    if (!t.value || f.ganttBarConfig.pushOnOverlap === !1)
      return;
    for (const d of ["left", "right"]) {
      const a = d, { gapDistanceSoFar: e, bundleBarsAndGapDist: o } = s(
        f,
        0,
        a
      );
      let l = e;
      const B = o;
      if (!B)
        continue;
      for (let v = 0; v < B.length; v++) {
        const b = B[v].bar, w = B[v].gapDistance;
        n(b.ganttBarConfig.bundle).filter(
          (h) => h !== b
        ).forEach((h) => {
          const x = s(h, w, a), r = x.gapDistanceSoFar, y = x.bundleBarsAndGapDist;
          r != null && (!l || r < l) && (l = r), y.forEach((m) => {
            B.find((_) => _.bar === m.bar) || B.push(m);
          });
        });
      }
      const D = document.getElementById(f.ganttBarConfig.id);
      l != null && a === "left" ? f.ganttBarConfig.dragLimitLeft = D.offsetLeft - l : l != null && a === "right" && (f.ganttBarConfig.dragLimitRight = D.offsetLeft + D.offsetWidth + l);
    }
    n(f.ganttBarConfig.bundle).forEach((d) => {
      d.ganttBarConfig.dragLimitLeft = f.ganttBarConfig.dragLimitLeft, d.ganttBarConfig.dragLimitRight = f.ganttBarConfig.dragLimitRight;
    });
  }, s = (f, g = 0, d) => {
    const a = f.ganttBarConfig.bundle ? [{ bar: f, gapDistance: g }] : [];
    let e = f, o = c(e, d);
    if (d === "left")
      for (; o; ) {
        const l = document.getElementById(e.ganttBarConfig.id), B = document.getElementById(o.ganttBarConfig.id), D = B.offsetLeft + B.offsetWidth;
        if (g += l.offsetLeft - D, o.ganttBarConfig.immobile)
          return { gapDistanceSoFar: g, bundleBarsAndGapDist: a };
        o.ganttBarConfig.bundle && a.push({
          bar: o,
          gapDistance: g
        }), e = o, o = c(o, "left");
      }
    if (d === "right")
      for (; o; ) {
        const l = document.getElementById(e.ganttBarConfig.id), B = document.getElementById(o.ganttBarConfig.id), D = l.offsetLeft + l.offsetWidth;
        if (g += B.offsetLeft - D, o.ganttBarConfig.immobile)
          return { gapDistanceSoFar: g, bundleBarsAndGapDist: a };
        o.ganttBarConfig.bundle && a.push({
          bar: o,
          gapDistance: g
        }), e = o, o = c(o, "right");
      }
    return { gapDistanceSoFar: null, bundleBarsAndGapDist: a };
  }, c = (f, g) => {
    const d = document.getElementById(f.ganttBarConfig.id), a = i().find((o) => o.includes(f)) || [];
    let e = [];
    return g === "left" ? e = a.filter((o) => {
      const l = document.getElementById(o.ganttBarConfig.id);
      return l && l.offsetLeft < d.offsetLeft && o.ganttBarConfig.pushOnOverlap !== !1;
    }) : e = a.filter((o) => {
      const l = document.getElementById(o.ganttBarConfig.id);
      return l && l.offsetLeft > d.offsetLeft && o.ganttBarConfig.pushOnOverlap !== !1;
    }), e.length > 0 ? e.reduce((o, l) => {
      const B = document.getElementById(o.ganttBarConfig.id), D = document.getElementById(l.ganttBarConfig.id), v = Math.abs(B.offsetLeft - d.offsetLeft), b = Math.abs(D.offsetLeft - d.offsetLeft);
      return v < b ? o : l;
    }, e[0]) : null;
  };
  return {
    setDragLimitsOfGanttBar: u
  };
}
const Re = ["id"], Ye = { class: "g-gantt-bar-label" }, Ae = /* @__PURE__ */ U("div", { class: "g-gantt-bar-handle-left" }, null, -1), He = /* @__PURE__ */ U("div", { class: "g-gantt-bar-handle-right" }, null, -1), Pe = /* @__PURE__ */ W({
  __name: "GGanttBar",
  props: {
    bar: null
  },
  setup(t) {
    const i = t, n = Nt(), u = A(), { rowHeight: s } = u, { bar: c } = J(i), { mapTimeToPosition: f, mapPositionToTime: g } = Bt(), { initDragOfBar: d, initDragOfBundle: a } = Ge(), { setDragLimitsOfGanttBar: e } = Ie(), o = $(!1), l = I(() => c.value.ganttBarConfig);
    function B(E) {
      l.value.bundle != null ? a(c.value, E) : d(c.value, E), o.value = !0;
    }
    const D = () => {
      e(c.value), !l.value.immobile && (window.addEventListener("mousemove", B, {
        once: !0
      }), window.addEventListener(
        "mouseup",
        () => {
          window.removeEventListener("mousemove", B), o.value = !1;
        },
        { once: !0 }
      ));
    }, v = lt(Ht), b = (E) => {
      var k;
      E.preventDefault(), E.type === "mousedown" && D();
      const C = (k = v == null ? void 0 : v.value) == null ? void 0 : k.getBoundingClientRect();
      if (!C)
        return;
      const S = g(E.clientX - C.left);
      n(E, c.value, S);
    }, { barStart: w, barEnd: p, width: h, chartStart: x, chartEnd: r, chartSize: y } = u, m = $(0), _ = $(0);
    return Tt(() => {
      ut(
        [c, h, x, r, y.width],
        () => {
          m.value = f(c.value[w.value]), _.value = f(c.value[p.value]);
        },
        { deep: !0, immediate: !0 }
      );
    }), (E, C) => (M(), L("div", {
      id: O(l).id,
      class: "g-gantt-bar",
      style: P({
        ...O(l).style,
        position: "absolute",
        top: `${O(s) * 0.1}px`,
        left: `${m.value}px`,
        width: `${_.value - m.value}px`,
        height: `${O(s) * 0.8}px`,
        zIndex: o.value ? 3 : 2
      }),
      onMousedown: b,
      onClick: b,
      onDblclick: b,
      onMouseenter: b,
      onMouseleave: b,
      onContextmenu: b
    }, [
      U("div", Ye, [
        H(E.$slots, "default", { bar: O(c) }, () => [
          U("div", null, X(O(l).label || ""), 1)
        ])
      ]),
      O(l).hasHandles ? (M(), L(Q, { key: 0 }, [
        Ae,
        He
      ], 64)) : Z("", !0)
    ], 44, Re));
  }
});
const Ue = /* @__PURE__ */ W({
  __name: "GGanttRow",
  props: {
    label: null,
    bars: null,
    highlightOnHover: { type: Boolean }
  },
  emits: ["drop"],
  setup(t, { emit: i }) {
    const n = t, { rowHeight: u, colors: s } = A(), { highlightOnHover: c } = J(n), f = $(!1), g = I(() => ({
      height: `${u.value}px`,
      background: (c == null ? void 0 : c.value) && f.value ? s.value.hoverHighlight : null
    })), { mapPositionToTime: d } = Bt(), a = $(null);
    rt(Ht, a);
    const e = (o) => {
      var v;
      const l = (v = a.value) == null ? void 0 : v.getBoundingClientRect();
      if (!l) {
        console.error("Vue-Ganttastic: failed to find bar container element for row.");
        return;
      }
      const B = o.clientX - l.left, D = d(B);
      i("drop", { e: o, datetime: D });
    };
    return (o, l) => (M(), L("div", {
      class: "g-gantt-row",
      style: P(O(g)),
      onDragover: l[0] || (l[0] = ne((B) => f.value = !0, ["prevent"])),
      onDragleave: l[1] || (l[1] = (B) => f.value = !1),
      onDrop: l[2] || (l[2] = (B) => e(B)),
      onMouseover: l[3] || (l[3] = (B) => f.value = !0),
      onMouseleave: l[4] || (l[4] = (B) => f.value = !1)
    }, [
      U("div", {
        class: "g-gantt-row-label",
        style: P({ background: O(s).primary, color: O(s).text })
      }, [
        H(o.$slots, "label", {}, () => [
          it(X(t.label), 1)
        ])
      ], 4),
      U("div", ae({
        ref_key: "barContainer",
        ref: a,
        class: "g-gantt-row-bars-container"
      }, o.$attrs), [
        wt(re, {
          name: "bar-transition",
          tag: "div"
        }, {
          default: q(() => [
            (M(!0), L(Q, null, ot(t.bars, (B) => (M(), st(Pe, {
              key: B.ganttBarConfig.id,
              bar: B
            }, {
              default: q(() => [
                H(o.$slots, "bar-label", { bar: B })
              ]),
              _: 2
            }, 1032, ["bar"]))), 128))
          ]),
          _: 3
        })
      ], 16)
    ], 36));
  }
});
function je() {
  N.extend(oe), N.extend(ie), N.extend(se), N.extend(le);
}
const Ve = {
  install(t, i) {
    je(), t.component("GGanttChart", $e), t.component("GGanttRow", Ue);
  }
};
function K(t, i = "top") {
  if (!t || typeof document > "u")
    return;
  const n = document.head, u = document.createElement("style");
  i === "top" && n.firstChild ? n.insertBefore(u, n.firstChild) : n.appendChild(u), u.appendChild(document.createTextNode(t));
}
K(`
.g-gantt-chart {
  position: relative;
  display: flex;
  flex-direction: column;
  overflow-x: hidden;
  -webkit-touch-callout: none;
  -webkit-user-select: none;
     -moz-user-select: none;
          user-select: none;
  border-radius: 5px;
  font-feature-settings: "tnum";
  font-variant-numeric: tabular-nums;
}
.g-gantt-rows-container {
  position: relative;
}
`, "top");
K(`
.g-gantt-row {
  width: 100%;
  transition: background 0.4s;
  position: relative;
}
.g-gantt-row > .g-gantt-row-bars-container {
  position: relative;
  border-top: 1px solid #eaeaea;
  width: 100%;
  border-bottom: 1px solid #eaeaea;
}
.g-gantt-row-label {
  position: absolute;
  top: 0;
  left: 0px;
  padding: 0px 8px;
  display: flex;
  align-items: center;
  height: 60%;
  min-height: 20px;
  font-size: 0.8em;
  font-weight: bold;
  border-bottom-right-radius: 6px;
  background: #f2f2f2;
  z-index: 3;
  box-shadow: 0px 1px 4px 0px rgba(0, 0, 0, 0.6);
}
.bar-transition-leave-active,
.bar-transition-enter-active {
  transition: all 0.2s;
}
.bar-transition-enter-from,
.bar-transition-leave-to {
  transform: scale(0.8);
  opacity: 0;
}
`, "top");
K(`
.g-grid-container {
  position: absolute;
  top: 0;
  left: 0%;
  width: 100%;
  height: 100%;
  display: flex;
  justify-content: space-between;
}
.g-grid-line {
  width: 1px;
  height: 100%;
  border-left: 1px solid #eaeaea;
}
`, "top");
K(`
.g-gantt-tooltip {
  position: fixed;
  background: black;
  color: white;
  z-index: 4;
  font-size: 0.85em;
  padding: 5px;
  border-radius: 3px;
  transition: opacity 0.2s;
  display: flex;
  align-items: center;
  font-feature-settings: "tnum";
  font-variant-numeric: tabular-nums;
}
.g-gantt-tooltip:before {
  content: "";
  position: absolute;
  top: 0;
  left: 10%;
  width: 0;
  height: 0;
  border: 10px solid transparent;
  border-bottom-color: black;
  border-top: 0;
  margin-left: -5px;
  margin-top: -5px;
}
.g-gantt-tooltip-color-dot {
  width: 8px;
  height: 8px;
  border-radius: 100%;
  margin-right: 4px;
}
.g-fade-enter-active,
.g-fade-leave-active {
  transition: opacity 0.3s ease;
}
.g-fade-enter-from,
.g-fade-leave-to {
  opacity: 0;
}
`, "top");
K(`
.g-timeaxis {
  position: sticky;
  top: 0;
  width: 100%;
  height: 8vh;
  min-height: 75px;
  background: white;
  z-index: 4;
  box-shadow: 0px 1px 3px 2px rgba(50, 50, 50, 0.5);
  display: flex;
  flex-direction: column;
}
.g-timeunits-container {
  display: flex;
  width: 100%;
  height: 50%;
}
.g-timeunit {
  height: 100%;
  font-size: 65%;
  display: flex;
  flex-direction: column;
  justify-content: center;
}
.g-upper-timeunit {
  display: flex;
  height: 100%;
  justify-content: center;
  align-items: center;
}
.g-timeaxis-hour-pin {
  width: 1px;
  height: 10px;
}
`, "top");
K(`
.g-gantt-bar {
  display: flex;
  justify-content: center;
  align-items: center;
  background: cadetblue;
  overflow: hidden;
}
.g-gantt-bar-label {
  width: 100%;
  height: 100%;
  box-sizing: border-box;
  padding: 0 14px 0 14px; /* 14px is the width of the handle */
  display: flex;
  justify-content: center;
  align-items: center;
}
.g-gantt-bar-label > * {
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}
.g-gantt-bar-handle-left,
.g-gantt-bar-handle-right {
  position: absolute;
  width: 10px;
  height: 100%;
  background: white;
  opacity: 0.7;
  border-radius: 0px;
  cursor: ew-resize;
  top: 0;
}
.g-gantt-bar-handle-left {
  left: 0;
}
.g-gantt-bar-handle-right {
  right: 0;
}
.g-gantt-bar-label img {
  pointer-events: none;
}
`, "top");
export {
  $e as GGanttChart,
  Ue as GGanttRow,
  Ve as default,
  je as extendDayjs,
  Ve as ganttastic
};
