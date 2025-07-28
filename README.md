# 🛍️ CatalogCave – Product Catalog App

A clean, modern ASP.NET Core MVC web application that showcases a product catalog using the [Fake Store API](https://fakestoreapi.com). Built using Razor Views and styled with Bootstrap 5.

---

## ✨ Features

- 🔍 **Live Search**: Search results update as the user types.
- 🗂 **Category Filtering**: Filter products by categories (e.g., Electronics, Jewelery).
- 🔃 **Sorting**: Sort by `Title` or `Price` in ascending or descending order.
- 🧹 **Clear Filters Button**: Resets all filters and shows all products.
- ⭐ **Product Ratings**: Star rating display with total review count.
- 🖼 **Responsive Product Cards**: Grid layout adapts to all screen sizes.
- 🔗 **Details Navigation**: Click “View Details” to see product details.

---

## 🔗 Route

---

## 🧾 Query Parameters

| Parameter   | Type    | Description                             | Example                     |
|-------------|---------|-----------------------------------------|-----------------------------|
| `Search`    | string  | Filter by product title                 | `Search=laptop`             |
| `Category`  | string  | Filter by product category              | `Category=electronics`      |
| `SortBy`    | string  | Field to sort by (`title`, `price`)    | `SortBy=price`              |
| `Descending`| boolean | Sort direction (true = DESC, false = ASC) | `Descending=true`         |

---

## 🧪 Example Use Cases

- Type `"bag"` in the search box → Products containing “bag” are shown.
- Select category `"electronics"` → Only electronics appear.
- Sort by `"Price"` descending → High to low prices.
- Click **Clear Filters** → Resets the UI.

---

## 🛠️ Technologies Used

- ASP.NET Core MVC (.NET 8)
- Razor Views
- Bootstrap 5
- `HttpClient` for API integration
- [Fake Store API](https://fakestoreapi.com)

---

## 🔐 Configuration

### Option 1: `appsettings.json` (for local dev)

```json
"FakeStoreApi": {
  "BaseUrl": "https://fakestoreapi.com",
  "ProductsEndpoint": "/products",
  "ProductByIdEndpoint": "/products/{id}"
}
