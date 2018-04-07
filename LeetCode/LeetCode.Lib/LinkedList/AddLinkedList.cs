namespace LeetCode.Lib.LinkedList
{
    public class AddLinkedList
    {
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null) return null;

            var sum = (l1?.val).GetValueOrDefault() + (l2?.val).GetValueOrDefault();
            var newVal = sum % 10;

            var carryover = (sum / 10) > 0;
            if (carryover)
            {
                l1 = l1 ?? new ListNode(0);
                l1.next = l1.next ?? new ListNode(0);
                l1.next.val++;
            }

            var newNode = new ListNode(newVal)
            {
                next = AddTwoNumbers(l1?.next, l2?.next)
            };
            return newNode;
        }
    }
}