# wpf-checkbox
Simple collapsable/expandable checkbox using MVVM pattern

![wpf](https://github.com/San94/wpf-checkbox/assets/22365229/277ef10e-4752-4229-a88b-71f64ad8350a)

## Functionality
- Checking a parent item should check all child items, unchecking a parent should uncheck all
children. An indeterminate check state should be supported for only parent items.
- “Collapse” should collapse the tree to display only the root test items, “Expand” should expand all
test items.
- “Back” should only be enabled if any checkbox is checked, and reset all check boxes.
- “Start” should only be enabled if any checkbox is checked, and show a popup with the display names
for all checked tests
