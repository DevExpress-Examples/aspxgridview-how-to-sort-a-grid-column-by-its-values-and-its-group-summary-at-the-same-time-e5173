# ASPxGridView - How to sort a grid column by its values and its group summary at the same time


<p>This example demonstrates how to implement the following behavior:<br />
When a column is sorted, the grid displays groups based on the column's group summary value.  Rows inside the group are also sorted based on the column's sort order.</p><p>To do so, it is necessary to:<br />
1) Save the column's sort order in the grid's <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewASPxGridView_BeforeGetCallbackResulttopic"><u>BeforeGetCallbackResult</u></a> event handler;<br />
2) Restore this state in the grid's Init event hander.</p>

<br/>


