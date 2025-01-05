import { ItemContainer } from "./styles";

const SidebarItem = ({ Icon, Text }) => {
  return (
    <ItemContainer>
      <Icon style={{ marginRight: "10px" }} />
      {Text}
    </ItemContainer>
  );
};

export default SidebarItem;
